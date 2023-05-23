FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Source/Microservices/Content/Presentation/PartnerUp.Content.API/PartnerUp.Content.API.csproj", "PartnerUp.Content.API/"]
COPY ["Source/Microservices/Content/Core/PartnerUp.Content.Domain/PartnerUp.Content.Domain.csproj", "PartnerUp.Content.Domain/"]
COPY ["Source/Libraries/PartnerUp.Shared/PartnerUp.Shared.csproj", "PartnerUp.Shared/"]
COPY ["Source/Libraries/PartnerUp.EventBus.Messages/PartnerUp.EventBus.Messages.csproj", "PartnerUp.EventBus.Messages/"]
COPY ["Source/Microservices/Content/Infrastructure/PartnerUp.Content.Persistence/PartnerUp.Content.Persistence.csproj", "PartnerUp.Content.Persistence/"]
COPY ["Source/Microservices/Content/Core/PartnerUp.Content.Application/PartnerUp.Content.Application.csproj", "PartnerUp.Content.Application/"]
RUN dotnet restore "Source/Microservices/Content/Presentation/PartnerUp.Content.API/PartnerUp.Content.API.csproj"
COPY . .
WORKDIR "/src/PartnerUp.Content.API"
RUN dotnet build "PartnerUp.Content.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PartnerUp.Content.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PartnerUp.Content.API.dll"]
