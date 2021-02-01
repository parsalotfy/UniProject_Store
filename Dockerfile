# Get base sdk docker image from microsoft
# 5.0-alpine
# 5.0.102-1-alpine3.12-amd64
FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine AS build-env
WORKDIR /app

# Copy csproj file and restore any dependencies
#COPY *.csproj ./
#COPY ../SharedProject/*.csproj ./
#RUN dotnet restore

# Copy project files and build our release
#COPY . ./
#COPY ../SharedProject ./

COPY ./Store_API ./Store_API
COPY ./SharedProject ./SharedProject
RUN dotnet restore ./SharedProject
RUN dotnet restore ./Store_API

RUN dotnet publish ./Store_API -c Release -o out

# Generate runtime image
# 5.0.2-alpine3.12-amd64
FROM mcr.microsoft.com/dotnet/aspnet:5.0-alpine
WORKDIR /app
EXPOSE 80
COPY --from=build-env /app/out .
#ENTRYPOINT [ "dotnet", "Store_API.dll" ]

# docker build --no-cache  -t parsalotfy/store_api .
# docker run -p 8080:80  --rm -it  parsalotfy/store_api sh