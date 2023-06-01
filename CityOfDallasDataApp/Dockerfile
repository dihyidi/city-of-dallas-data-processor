FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CityOfDallasDataApp/CityOfDallasDataApp.csproj", "CityOfDallasDataApp/"]
RUN dotnet restore "CityOfDallasDataApp/CityOfDallasDataApp.csproj"
COPY . .
WORKDIR "/src/CityOfDallasDataApp"
RUN dotnet build "CityOfDallasDataApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CityOfDallasDataApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CityOfDallasDataApp.dll"]
