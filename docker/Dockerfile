FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.sln .
COPY ./kewcms/*.csproj ./kewcms/
RUN dotnet restore

# Copy everything else and build
COPY ./kewcms/. ./kewcms/
WORKDIR /app/kewcms
RUN dotnet publish -c Release -o out

# Build runtime image   
FROM microsoft/dotnet:2.1-aspnetcore-runtime AS runtime
WORKDIR /app/kewcms
COPY --from=build /app/kewcms/out ./
COPY ./kewcms/upload/ ./
ENTRYPOINT ["dotnet", "kewcms.dll"]