﻿FROM registry.cn-hangzhou.aliyuncs.com/masa/dotnet_sdk:8.0.100-1 AS publish
WORKDIR /src
COPY . .
ENV CSPROJ="src\MASA.OfficialWebsite.WebApp/MASA.OfficialWebsite.WebApp.csproj"

RUN dotnet restore $CSPROJ && dotnet publish $CSPROJ -c Release -o /app/publish

FROM registry.cn-hangzhou.aliyuncs.com/masa/dotnet_aspnet:8.0-1
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS=http://0.0.0.0:80
EXPOSE 80
ENTRYPOINT ["dotnet", "MASA.OfficialWebsite.WebApp.dll"]