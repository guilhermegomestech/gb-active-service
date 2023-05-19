
#Build Stage
FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine as build

#Pasta de trabalho no Container
WORKDIR /app
#Copiar da pasta local para a pasta do Container
COPY . .
RUN dotnet restore
RUN dotnet publish -o /app/published-app

FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine as runtime

# Fixed: Only the invariant culture is supported in globalization-invariant mode
RUN apk add --no-cache icu-libs krb5-libs libgcc libintl libssl1.1 libstdc++ zlib
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false

WORKDIR /app
COPY --from=build /app/published-app /app
ENTRYPOINT [ "dotnet", "/app/gb-active-service-api.dll" ]
