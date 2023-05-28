FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/PartnerUp.Gateway/PartnerUp.Gateway.csproj", "src/PartnerUp.Gateway/"]
COPY ["src/Libraries/PartnerUp.Shared/PartnerUp.Shared.csproj", "src/Libraries/PartnerUp.Shared/"]
RUN dotnet restore "src/PartnerUp.Gateway/PartnerUp.Gateway.csproj"
COPY . .
WORKDIR "/src/src/PartnerUp.Gateway"
RUN dotnet build "PartnerUp.Gateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PartnerUp.Gateway.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PartnerUp.Gateway.dll"]
