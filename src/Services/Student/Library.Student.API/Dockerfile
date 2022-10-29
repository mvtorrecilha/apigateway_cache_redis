FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/Student/Library.Student.API/Library.Student.API.csproj", "Services/Student/Library.Student.API/"]
COPY ["Services/Student/Infrastructure/Library.Student.Infrastructure.Data/Library.Student.Infrastructure.Data.csproj", "Services/Student/Infrastructure/Library.Student.Infrastructure.Data/"]
COPY ["Services/Student/Library.Student.Domain/Library.Student.Domain.csproj", "Services/Student/Library.Student.Domain/"]
RUN dotnet restore "Services/Student/Library.Student.API/Library.Student.API.csproj"
COPY . .
WORKDIR "/src/Services/Student/Library.Student.API"
RUN dotnet build "Library.Student.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Library.Student.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Library.Student.API.dll"]