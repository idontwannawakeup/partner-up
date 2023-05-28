FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Microservices/Identity/People/PartnerUp.Identity.People.API/PartnerUp.Identity.People.API.csproj", "src/Microservices/Identity/People/PartnerUp.Identity.People.API/"]
COPY ["src/Microservices/Identity/People/PartnerUp.Identity.People.BusinessLogic/PartnerUp.Identity.People.BusinessLogic.csproj", "src/Microservices/Identity/People/PartnerUp.Identity.People.BusinessLogic/"]
COPY ["src/Microservices/Identity/Persistence/PartnerUp.Identity.Persistence.People/PartnerUp.Identity.Persistence.People.csproj", "src/Microservices/Identity/Persistence/PartnerUp.Identity.Persistence.People/"]
COPY ["src/Libraries/PartnerUp.Shared/PartnerUp.Shared.csproj", "src/Libraries/PartnerUp.Shared/"]
COPY ["src/Libraries/PartnerUp.EventBus.Messages/PartnerUp.EventBus.Messages.csproj", "src/Libraries/PartnerUp.EventBus.Messages/"]
RUN dotnet restore "src/Microservices/Identity/People/PartnerUp.Identity.People.API/PartnerUp.Identity.People.API.csproj"
COPY . .
WORKDIR "/src/src/Microservices/Identity/People/PartnerUp.Identity.People.API"
RUN dotnet build "PartnerUp.Identity.People.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PartnerUp.Identity.People.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PartnerUp.Identity.People.API.dll"]
