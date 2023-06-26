FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Artisan.II/Server/Artisan.II.Server.csproj", "Artisan.II/Server/"]
COPY ["Artisan.II/Client/Artisan.II.Client.csproj", "Artisan.II/Client/"]
COPY ["Artisan.II/Shared/Artisan.II.Shared.csproj", "Artisan.II/Shared/"]
RUN dotnet restore "Artisan.II/Server/Artisan.II.Server.csproj"
COPY . .
WORKDIR "/src/Artisan.II/Server"
RUN dotnet build "Artisan.II.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Artisan.II.Server.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Artisan.II.Server.dll"]
