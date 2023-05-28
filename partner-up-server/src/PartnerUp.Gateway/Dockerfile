FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Source/PartnerUp.Gateway/PartnerUp.Gateway.csproj", "PartnerUp.Gateway/"]
COPY ["Source/Libraries/PartnerUp.Shared/PartnerUp.Shared.csproj", "PartnerUp.Shared/"]
RUN dotnet restore "Source/PartnerUp.Gateway/PartnerUp.Gateway.csproj"
COPY . .
WORKDIR "/src/PartnerUp.Gateway"
RUN dotnet build "PartnerUp.Gateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PartnerUp.Gateway.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PartnerUp.Gateway.dll"]
