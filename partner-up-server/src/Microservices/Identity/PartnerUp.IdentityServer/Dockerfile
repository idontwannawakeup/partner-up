FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Microservices/Identity/PartnerUp.IdentityServer/PartnerUp.IdentityServer.csproj", "src/Microservices/Identity/PartnerUp.IdentityServer/"]
COPY ["src/Libraries/PartnerUp.Shared/PartnerUp.Shared.csproj", "src/Libraries/PartnerUp.Shared/"]
COPY ["src/Libraries/PartnerUp.EventBus.Messages/PartnerUp.EventBus.Messages.csproj", "src/Libraries/PartnerUp.EventBus.Messages/"]
COPY ["src/Microservices/Identity/Persistence/PartnerUp.Identity.Persistence.People/PartnerUp.Identity.Persistence.People.csproj", "src/Microservices/Identity/Persistence/PartnerUp.Identity.Persistence.People/"]
COPY ["src/Microservices/Identity/Persistence/PartnerUp.Identity.Persistence.Operational/PartnerUp.Identity.Persistence.Operational.csproj", "src/Microservices/Identity/Persistence/PartnerUp.Identity.Persistence.Operational/"]
COPY ["src/Microservices/Identity/Persistence/PartnerUp.Identity.Persistence.Configuration/PartnerUp.Identity.Persistence.Configuration.csproj", "src/Microservices/Identity/Persistence/PartnerUp.Identity.Persistence.Configuration/"]
RUN dotnet restore "src/Microservices/Identity/PartnerUp.IdentityServer/PartnerUp.IdentityServer.csproj"
COPY . .
WORKDIR "/src/src/Microservices/Identity/PartnerUp.IdentityServer"
RUN dotnet build "PartnerUp.IdentityServer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PartnerUp.IdentityServer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PartnerUp.IdentityServer.dll"]
