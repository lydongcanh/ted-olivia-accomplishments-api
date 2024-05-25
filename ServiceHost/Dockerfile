FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["ted-olivia-accomplishments-api/ServiceHost.csproj", "ted-olivia-accomplishments-api/"]
RUN dotnet restore "ted-olivia-accomplishments-api/ServiceHost.csproj"
COPY . .
WORKDIR "/src/ted-olivia-accomplishments-api"
RUN dotnet build "ServiceHost.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ServiceHost.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ted-olivia-accomplishments-api.dll"]
