FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Source/Microservices/Social/PartnerUp.Social.API/PartnerUp.Social.API.csproj", "PartnerUp.Social.API/"]
COPY ["Source/Microservices/Social/PartnerUp.Social.BusinessLogic/PartnerUp.Social.BusinessLogic.csproj", "PartnerUp.Social.BusinessLogic/"]
COPY ["Source/Libraries/PartnerUp.Shared/PartnerUp.Shared.csproj", "PartnerUp.Shared/"]
COPY ["Source/Microservices/Social/PartnerUp.Social.DataAccess/PartnerUp.Social.DataAccess.csproj", "PartnerUp.Social.DataAccess/"]
COPY ["Source/Libraries/PartnerUp.EventBus.Messages/PartnerUp.EventBus.Messages.csproj", "PartnerUp.EventBus.Messages/"]
RUN dotnet restore "Source/Microservices/Social/PartnerUp.Social.API/PartnerUp.Social.API.csproj"
COPY . .
WORKDIR "/src/PartnerUp.Social.API"
RUN dotnet build "PartnerUp.Social.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PartnerUp.Social.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PartnerUp.Social.API.dll"]
