FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Microservices/Recommendations/PartnerUp.Recommendations.API/PartnerUp.Recommendations.API.csproj", "src/Microservices/Recommendations/PartnerUp.Recommendations.API/"]
RUN dotnet restore "src/Microservices/Recommendations/PartnerUp.Recommendations.API/PartnerUp.Recommendations.API.csproj"
COPY . .
WORKDIR "/src/src/Microservices/Recommendations/PartnerUp.Recommendations.API"
RUN dotnet build "PartnerUp.Recommendations.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PartnerUp.Recommendations.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PartnerUp.Recommendations.API.dll"]
