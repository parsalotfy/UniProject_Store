# Get base sdk docker image from microsoft
FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine AS build-env
WORKDIR /app

# Copy project files
COPY ./Store_Client ./Store_Client
COPY ./SharedProject ./SharedProject

# Build our release
RUN dotnet publish ./Store_Client -c Release -o out

# Generate runtime image
FROM nginx:alpine
WORKDIR /usr/share/nginx/html
COPY --from=build-env /app/out/wwwroot .


# -----------------------------------
# ----------- Build -----------------
# -----------------------------------

# docker build --no-cache -t parsalotfy/store_client -f Dockerfile_Client.dockerfile .


# -----------------------------------
# ----------- Debug -----------------
# -----------------------------------

# For debugging :
# docker run -p 8081:80 --rm -it parsalotfy/store_client sh

# For just run client itself
# docker run -p 8081:80 --rm parsalotfy/store_client

# Result : http://localhost/

# for changing port : 
# https://stackoverflow.com/questions/48669548/why-does-aspnet-core-start-on-port-80-from-within-docker

# -----------------------------------
# ----------- Deploy ----------------
# -----------------------------------

# Run client inside that network
# docker run -p 8081:80 --rm --name client_container --network store_network parsalotfy/store_client

# Run Without a network
# docker run -d -p 8082:80 --rm --name client_container parsalotfy/store_client

# To push image to dockerhub :
# docker push parsalotfy/store_client

# to go into a running countainer :
# docker exec -it <container name> sh