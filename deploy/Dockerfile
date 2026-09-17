FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 8080

ENV ASPNETCORE_HTTP_PORTS=8080

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY ["Galasy.Pedidos.Presentation/Galasy.Pedidos.Presentation.csproj", "Galasy.Pedidos.Presentation/"]
RUN dotnet restore "Galasy.Pedidos.Presentation/Galasy.Pedidos.Presentation.csproj"

COPY . .
WORKDIR "/src/Galasy.Pedidos.Presentation"
RUN dotnet publish "Galasy.Pedidos.Presentation.csproj" \
    --configuration Release \
    --output /app/publish \
    --no-restore

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Galasy.Pedidos.Presentation.dll"]
