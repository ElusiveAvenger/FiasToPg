FROM mcr.microsoft.com/dotnet/core/runtime:2.2-stretch-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src

COPY . .

RUN dotnet restore "FiasToPg.csproj"

WORKDIR "."
RUN dotnet build "FiasToPg.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "FiasToPg.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .

VOLUME ["/data"]

ENTRYPOINT ["dotnet", "FiasToPg.dll"]
