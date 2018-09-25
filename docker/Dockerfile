FROM microsoft/dotnet:2.1-sdk AS build
COPY ../kewcms/*.csproj ./app/kewcms/
WORKDIR /app/kewcms
RUN dotnet restore

COPY ../kewcms/. ./
RUN dotnet publish -o out /p:PublishWithAspNetCoreTargetManifest="false"

FROM microsoft/dotnet:2.1-runtime AS runtime
ENV ASPNETCORE_URLS http://+:5000
WORKDIR /app
COPY --from=build /app/kewcms/out ./
ENTRYPOINT ["dotnet", "kewcms.dll"]