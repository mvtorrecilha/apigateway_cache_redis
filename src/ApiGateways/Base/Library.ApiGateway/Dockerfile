FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ApiGateways/Base/Library.ApiGateway/Library.ApiGateway.csproj", "ApiGateways/Base/Library.ApiGateway/"]
RUN dotnet restore "ApiGateways/Base/Library.ApiGateway/Library.ApiGateway.csproj"
COPY . .
WORKDIR "/src/ApiGateways/Base/Library.ApiGateway"
RUN dotnet publish --no-restore -c Release -o /app

FROM build AS publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Library.ApiGateway.dll"]