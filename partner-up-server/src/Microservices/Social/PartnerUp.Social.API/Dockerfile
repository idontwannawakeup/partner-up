FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Microservices/Social/PartnerUp.Social.API/PartnerUp.Social.API.csproj", "src/Microservices/Social/PartnerUp.Social.API/"]
COPY ["src/Libraries/PartnerUp.Shared/PartnerUp.Shared.csproj", "src/Libraries/PartnerUp.Shared/"]
COPY ["src/Libraries/PartnerUp.EventBus.Messages/PartnerUp.EventBus.Messages.csproj", "src/Libraries/PartnerUp.EventBus.Messages/"]
COPY ["src/Microservices/Social/PartnerUp.Social.BusinessLogic/PartnerUp.Social.BusinessLogic.csproj", "src/Microservices/Social/PartnerUp.Social.BusinessLogic/"]
COPY ["src/Microservices/Social/PartnerUp.Social.DataAccess/PartnerUp.Social.DataAccess.csproj", "src/Microservices/Social/PartnerUp.Social.DataAccess/"]
RUN dotnet restore "src/Microservices/Social/PartnerUp.Social.API/PartnerUp.Social.API.csproj"
COPY . .
WORKDIR "/src/src/Microservices/Social/PartnerUp.Social.API"
RUN dotnet build "PartnerUp.Social.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PartnerUp.Social.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PartnerUp.Social.API.dll"]
