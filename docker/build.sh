#!/bin/bash
echo "Start build server ..."
cd ../server
msbuild /target:build \
    /property:GenerateFullPaths=true \
    /property:Configuration=Release "/verbosity:minimal" \
    SoilSample.sln
if [ $? -ne 0 ]; then
    echo "Server build error!"
    exit 1
fi
echo "Server build success, copy build output to docker build ..."
mkdir -p ../docker/build/web && cp -r bin ../docker/build/web \
    && mv ../docker/build/web/bin/Castle.Services.Logging.log4netIntegration.dll ../docker/build/web/bin/Castle.Services.Logging.Log4netIntegration.dll \
    && mv ../docker/build/web/bin/Castle.Services.Logging.log4netIntegration.xml ../docker/build/web/bin/Castle.Services.Logging.Log4netIntegration.xml \
    && mv ../docker/build/web/bin/*.config ../docker/build/web \
    && mv ../docker/build/web/SoilSample.Entry.exe.config ../docker/build/web/web.config \
    && cp ../docker/build/web/bin/SoilSample.Api.xml ../docker/build/web/ 
if [ $? -ne 0 ]; then
    echo "Copy server build output to docker build error!"
    exit 2
fi
echo "Start build client..."
cd ../client
sed -i 's/127\.0\.0\.1:4610/113\.108\.142\.147:20138/' src/app/app.config.ts \
&& npm run build-prod
if [ $? -ne 0 ]; then
    echo "Client build error!"
    exit 3
fi
echo "Client build success, copy build output to docker build ..."

cp -r dist/* ../docker/build/web
if [ $? -ne 0 ]; then
    echo "Copy client build to docker build error!"
    exit 4
fi
echo "Copy config confile to docker"
cd ../docker
cp jexus-conf build/default && cp Dockerfile build
if [ $? -ne 0 ]; then
    echo "Copy config confile to docker error!"
    exit 5
fi
echo "Start build docker image ..."
cd build && docker build -t kerwincui/soil-sample . \
    && docker tag kerwincui/soil-sample kerwincui/soil-sample:$(date +%Y%m%d) \
    && cd ..
if [ $? -ne 0 ]; then
    echo "Build docker image error!"
    exit 6
fi
echo "Remove temp build folder ..."
rm -rf build
if [ $? -ne 0 ]; then
    echo "Remove temp build error!"
    exit 7
fi
