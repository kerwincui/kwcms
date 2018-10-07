1. 切换到项目目录kewcms

2. 创建docker镜像: `docker build -t kewcms -f ./docker/Dockerfile .`

3. 运行docker容器: `docker run -n kewcms -r unless-stopped -p 5000:80 -d kewcms`

>参考[https://github.com/dotnet/dotnet-docker](https://github.com/dotnet/dotnet-docker/blob/master/samples/aspnetapp/Dockerfile)

