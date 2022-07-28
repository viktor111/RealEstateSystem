FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["RealEstateSystem/RealEstateSystem.csproj", "RealEstateSystem/"]
RUN dotnet restore "RealEstateSystem/RealEstateSystem.csproj"
COPY . .
WORKDIR "/src/RealEstateSystem"
RUN dotnet build "RealEstateSystem.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RealEstateSystem.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RealEstateSystem.dll"]
