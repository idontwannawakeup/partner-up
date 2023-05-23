FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Microservices/Content/Presentation/PartnerUp.Content.API/PartnerUp.Content.API.csproj", "src/Microservices/Content/Presentation/PartnerUp.Content.API/"]
COPY ["src/Libraries/PartnerUp.Shared/PartnerUp.Shared.csproj", "src/Libraries/PartnerUp.Shared/"]
COPY ["src/Libraries/PartnerUp.EventBus.Messages/PartnerUp.EventBus.Messages.csproj", "src/Libraries/PartnerUp.EventBus.Messages/"]
COPY ["src/Microservices/Content/Infrastructure/PartnerUp.Content.Persistence/PartnerUp.Content.Persistence.csproj", "src/Microservices/Content/Infrastructure/PartnerUp.Content.Persistence/"]
COPY ["src/Microservices/Content/Core/PartnerUp.Content.Domain/PartnerUp.Content.Domain.csproj", "src/Microservices/Content/Core/PartnerUp.Content.Domain/"]
COPY ["src/Microservices/Content/Core/PartnerUp.Content.Application/PartnerUp.Content.Application.csproj", "src/Microservices/Content/Core/PartnerUp.Content.Application/"]
RUN dotnet restore "src/Microservices/Content/Presentation/PartnerUp.Content.API/PartnerUp.Content.API.csproj"
COPY . .
WORKDIR "/src/src/Microservices/Content/Presentation/PartnerUp.Content.API"
RUN dotnet build "PartnerUp.Content.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PartnerUp.Content.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PartnerUp.Content.API.dll"]
