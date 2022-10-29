#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/Book/Library.Book.API/Library.Book.API.csproj", "Services/Book/Library.Book.API/"]
COPY ["Services/Book/Infrastructure/Library.Book.Infrastructure.Data/Library.Book.Infrastructure.Data.csproj", "Services/Book/Infrastructure/Library.Book.Infrastructure.Data/"]
COPY ["Services/Book/Library.Book.Domain/Library.Book.Domain.csproj", "Services/Book/Library.Book.Domain/"]
RUN dotnet restore "Services/Book/Library.Book.API/Library.Book.API.csproj"
COPY . .
WORKDIR "/src/Services/Book/Library.Book.API"
RUN dotnet build "Library.Book.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Library.Book.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Library.Book.API.dll"]