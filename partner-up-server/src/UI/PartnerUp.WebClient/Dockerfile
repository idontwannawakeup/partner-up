FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/UI/PartnerUp.WebClient/PartnerUp.WebClient.csproj", "src/UI/PartnerUp.WebClient/"]
RUN dotnet restore "src/UI/PartnerUp.WebClient/PartnerUp.WebClient.csproj"
COPY . .
WORKDIR "/src/src/UI/PartnerUp.WebClient"
RUN dotnet build "PartnerUp.WebClient.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PartnerUp.WebClient.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PartnerUp.WebClient.dll"]
