FROM mcr.microsoft.com/dotnet/core/sdk:2.1 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
COPY *.sln ./
RUN dotnet restore

# Copy everything else and publish
COPY . ./
RUN dotnet publish -c Release -o out

# Create Certificates
WORKDIR /app/out
RUN dotnet dev-certs https -ep "localhost.pfx" -p 1234 --trust

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:2.1 as runtime
WORKDIR /app
RUN dotnet --info
COPY --from=build-env /app/out ./
CMD dotnet DistripackAPI.dll
