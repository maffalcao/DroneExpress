FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /
COPY ["Src.csproj", "Scr/"]
RUN dotnet restore "Scr.csproj"

COPY . .
WORKDIR /Src
RUN dotnet build "Src.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Src.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Application.dll"]