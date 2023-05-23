FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 90
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Source/Microservices/WorkManagement/Presentation/PartnerUp.WorkManagement.API/PartnerUp.WorkManagement.API.csproj", "PartnerUp.WorkManagement.API/"]
COPY ["Source/Microservices/WorkManagement/Core/PartnerUp.WorkManagement.Domain/PartnerUp.WorkManagement.Domain.csproj", "PartnerUp.WorkManagement.Domain/"]
COPY ["Source/Libraries/PartnerUp.Shared/PartnerUp.Shared.csproj", "PartnerUp.Shared/"]
COPY ["Source/Libraries/PartnerUp.EventBus.Messages/PartnerUp.EventBus.Messages.csproj", "PartnerUp.EventBus.Messages/"]
COPY ["Source/Microservices/WorkManagement/Infrastructure/PartnerUp.WorkManagement.Persistence/PartnerUp.WorkManagement.Persistence.csproj", "PartnerUp.WorkManagement.Persistence/"]
COPY ["Source/Microservices/WorkManagement/Core/PartnerUp.WorkManagement.Application/PartnerUp.WorkManagement.Application.csproj", "PartnerUp.WorkManagement.Application/"]
RUN dotnet restore "Source/Microservices/WorkManagement/Presentation/PartnerUp.WorkManagement.API/PartnerUp.WorkManagement.API.csproj"
COPY . .
WORKDIR "/src/PartnerUp.WorkManagement.API"
RUN dotnet build "PartnerUp.WorkManagement.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PartnerUp.WorkManagement.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PartnerUp.WorkManagement.API.dll"]
