FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["NewsWebsite.WebAPI/NewsWebsite.WebAPI.csproj", "NewsWebsite.WebAPI/"]
RUN dotnet restore "NewsWebsite.WebAPI/NewsWebsite.WebAPI.csproj"
COPY . .
WORKDIR "/src/NewsWebsite.WebAPI"
RUN dotnet build "NewsWebsite.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NewsWebsite.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NewsWebsite.WebAPI.dll"]
