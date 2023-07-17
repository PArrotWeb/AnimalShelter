FROM mcr.microsoft.com/dotnet/aspnet:8.0-preview-jammy AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0-preview-jammy AS build
WORKDIR /src
COPY ["AnimalShelter.WebApi/AnimalShelter.WebApi.csproj", "AnimalShelter.WebApi/"]
COPY ["AnimalShelter.Application/AnimalShelter.Application.csproj", "AnimalShelter.Application/"]
COPY ["AnimalShelter.Domain/AnimalShelter.Domain.csproj", "AnimalShelter.Domain/"]
COPY ["AnimalShelter.Persistence/AnimalShelter.Persistence.csproj", "AnimalShelter.Persistence/"]
RUN dotnet restore "AnimalShelter.WebApi/AnimalShelter.WebApi.csproj"
COPY . .
WORKDIR "/src/AnimalShelter.WebApi"
RUN dotnet build "AnimalShelter.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AnimalShelter.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AnimalShelter.WebApi.dll"]
