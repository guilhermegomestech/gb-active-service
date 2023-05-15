
#Imagem base
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
#Diretório da aplicação no Container
WORKDIR /app
#Portas da aplicação
EXPOSE 80
EXPOSE 443

#Build Stage
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
#Pasta de trabalho no Container
WORKDIR /src
#Copiar da pasta local para a pasta do Container
COPY ["./src/gb-active-service-api/gb-active-service-api.csproj", "src/gb-active-service-api/"]
RUN dotnet restore "./src/gb-active-service-api/gb-active-service-api.csproj"
COPY . .
WORKDIR "/src/src/gb-active-service-api"
RUN dotnet build "gb-active-service-api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "gb-active-service-api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "gb-active-service-api.dll"]
