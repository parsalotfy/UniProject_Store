# Get base sdk docker image from microsoft
FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine AS build-env
WORKDIR /app

# Copy project files
COPY ./Store_API ./Store_API
COPY ./SharedProject ./SharedProject

# Restore any dependencies
RUN dotnet restore ./SharedProject
RUN dotnet restore ./Store_API

# Build our release
RUN dotnet publish ./Store_API -c Release -o out

# Generate runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0-alpine
WORKDIR /app
EXPOSE 80
COPY --from=build-env /app/out .

# RUN
ENTRYPOINT [ "dotnet", "Store_API.dll" ]

# docker build --no-cache -t parsalotfy/store_api -f Dockerfile_API .
# docker build -t parsalotfy/store_api -f Dockerfile_API.dockerfile .
# docker run -p 8080:80 --rm -it parsalotfy/store_api sh
# docker run -p 8080:80 parsalotfy/store_api

# Result : http://localhost:8080/api/people

# for changing port : 
# https://stackoverflow.com/questions/48669548/why-does-aspnet-core-start-on-port-80-from-within-docker