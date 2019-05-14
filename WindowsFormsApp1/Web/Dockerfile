FROM microsoft/dotnet:latest
#拷贝当前文件夹下的文件到容器中系统的工作空间（注意：“.”后面有空格）
COPY . /webfordocker 
WORKDIR /webfordocker #容器中系统工作空间
EXPOSE 8011  


#容器中使用 ["dotnet","系统启动的dll"] 来运行应用程序
ENTRYPOINT ["dotnet", "Web.dll"]

CMD ["dotnet", "Web.dll", "--server.urls", "http://*:8011"]
