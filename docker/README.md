#1.切换到项目目录

#2.创建镜像
docker build -t kewcms -f ./docker/Dockerfile .      

#3服务器主目录（home）创建文件夹kewcms，复制项目的appsetting.json到文件夹

#4.运行容器
docker run --name kewcms \
       --volume ~/kewcms/appsettings.json:/app/kewcms/appsettings.json \
       --restart unless-stopped \
       --publish 5000:80 \
       --detach \
       kewcms

