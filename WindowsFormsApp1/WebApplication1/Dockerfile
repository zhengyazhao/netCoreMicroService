FROM microsoft/dotnet:latest
#拷贝当前文件夹下的文件到容器中系统的工作空间（注意：“.”后面有空格）
COPY . /webapi 
WORKDIR /webapi #容器中系统工作空间
EXPOSE 80  


#容器中使用 ["dotnet","系统启动的dll"] 来运行应用程序
ENTRYPOINT ["dotnet", "WebApplication1.dll"]