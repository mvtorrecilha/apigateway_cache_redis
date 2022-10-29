#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/Basket/Library.Basket.API/Library.Basket.API.csproj", "Services/Basket/Library.Basket.API/"]
COPY ["Infra/Library.Infra.Redis/Library.Infra.Redis.csproj", "Infra/Library.Infra.Redis/"]
RUN dotnet restore "Services/Basket/Library.Basket.API/Library.Basket.API.csproj"
COPY . .
WORKDIR "/src/Services/Basket/Library.Basket.API"
RUN dotnet build "Library.Basket.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Library.Basket.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Library.Basket.API.dll"]