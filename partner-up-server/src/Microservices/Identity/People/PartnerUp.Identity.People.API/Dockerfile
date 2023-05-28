FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Source/Microservices/Identity/People/PartnerUp.Identity.People.API/PartnerUp.Identity.People.API.csproj", "PartnerUp.Identity.People.API/"]
COPY ["Source/Libraries/PartnerUp.EventBus.Messages/PartnerUp.EventBus.Messages.csproj", "PartnerUp.EventBus.Messages/"]
COPY ["Source/Microservices/Identity/People/PartnerUp.Identity.People.BusinessLogic/PartnerUp.Identity.People.BusinessLogic.csproj", "PartnerUp.Identity.People.BusinessLogic/"]
COPY ["Source/Microservices/Identity/Persistence/PartnerUp.Identity.Persistence.People/PartnerUp.Identity.Persistence.People.csproj", "PartnerUp.Identity.Persistence.People/"]
COPY ["Source/Libraries/PartnerUp.Shared/PartnerUp.Shared.csproj", "PartnerUp.Shared/"]
RUN dotnet restore "Source/Microservices/Identity/People/PartnerUp.Identity.People.API/PartnerUp.Identity.People.API.csproj"
COPY . .
WORKDIR "/src/PartnerUp.Identity.People.API"
RUN dotnet build "PartnerUp.Identity.People.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PartnerUp.Identity.People.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PartnerUp.Identity.People.API.dll"]
