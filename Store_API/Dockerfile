# Get base sdk docker image from microsoft
FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine AS build-env
WORKDIR /app

# Copy project files
COPY ./Store_API ./Store_API
COPY ./SharedProject ./SharedProject

# Build our release
RUN dotnet publish ./Store_API -c Release -o out

# Generate runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0-alpine
WORKDIR /app
COPY --from=build-env /app/out .

# RUN
ENTRYPOINT [ "dotnet", "Store_API.dll" ]

# -----------------------------------
# ----------- Build -----------------
# -----------------------------------

# docker build --no-cache -t parsalotfy/store_api -f Dockerfile_API .
# docker build -t parsalotfy/store_api -f Dockerfile_API.dockerfile .

# -----------------------------------
# ----------- Debug -----------------
# -----------------------------------

# For debugging :
# docker run -p 8080:8080 --rm -it parsalotfy/store_api sh

# For just run api itself
# docker run --rm -p 8080:8080 parsalotfy/store_api

# Result : http://localhost:8080/api/people

# for changing port : 
# https://stackoverflow.com/questions/48669548/why-does-aspnet-core-start-on-port-80-from-within-docker

# -----------------------------------
# ----------- Deploy ----------------
# -----------------------------------

# First create a network :
# docker network create store_network

# Run api inside that network
# docker run -p 8080:8080 --rm --name api_container --network store_network parsalotfy/store_api

# Run Without network :
# first port is host machine port and second one is container port
# docker run -d -p 8081:8080 --rm --name api_container parsalotfy/store_api

# Test api in a alpine container : 
# docker run --rm -it --network store_network  alpine sh
# wget http://api_container/api/people

# To push image to dockerhub :
# docker push parsalotfy/store_api 


# to go into a running countainer :
# docker exec -it <container name> sh




