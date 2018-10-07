1. 切换到项目目录

2. 创建镜像
docker build -t kewcms -f ./docker/Dockerfile .      

3. 运行docker容器
docker run --name kewcms \
       --restart unless-stopped \
       --publish 5000:80 \
       --detach \
       kewcms

>参考[https://github.com/dotnet/dotnet-docker](https://github.com/dotnet/dotnet-docker/blob/master/samples/aspnetapp/Dockerfile)

