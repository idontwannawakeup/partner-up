FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 90
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Microservices/WorkManagement/Presentation/PartnerUp.WorkManagement.API/PartnerUp.WorkManagement.API.csproj", "src/Microservices/WorkManagement/Presentation/PartnerUp.WorkManagement.API/"]
COPY ["src/Microservices/WorkManagement/Core/PartnerUp.WorkManagement.Application/PartnerUp.WorkManagement.Application.csproj", "src/Microservices/WorkManagement/Core/PartnerUp.WorkManagement.Application/"]
COPY ["src/Libraries/PartnerUp.Shared/PartnerUp.Shared.csproj", "src/Libraries/PartnerUp.Shared/"]
COPY ["src/Microservices/WorkManagement/Core/PartnerUp.WorkManagement.Domain/PartnerUp.WorkManagement.Domain.csproj", "src/Microservices/WorkManagement/Core/PartnerUp.WorkManagement.Domain/"]
COPY ["src/Microservices/WorkManagement/Infrastructure/PartnerUp.WorkManagement.Persistence/PartnerUp.WorkManagement.Persistence.csproj", "src/Microservices/WorkManagement/Infrastructure/PartnerUp.WorkManagement.Persistence/"]
COPY ["src/Libraries/PartnerUp.EventBus.Messages/PartnerUp.EventBus.Messages.csproj", "src/Libraries/PartnerUp.EventBus.Messages/"]
RUN dotnet restore "src/Microservices/WorkManagement/Presentation/PartnerUp.WorkManagement.API/PartnerUp.WorkManagement.API.csproj"
COPY . .
WORKDIR "/src/src/Microservices/WorkManagement/Presentation/PartnerUp.WorkManagement.API"
RUN dotnet build "PartnerUp.WorkManagement.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PartnerUp.WorkManagement.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PartnerUp.WorkManagement.API.dll"]
