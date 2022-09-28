FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /src
COPY ["src/LinearTestPratico.WebAPI/LinearTestPratico.WebAPI.csproj", "src/LinearTestPratico.WebAPI/"]
RUN dotnet restore "src/LinearTestPratico.WebAPI/LinearTestPratico.WebAPI.csproj"
COPY . .
WORKDIR "/src/src/LinearTestPratico.WebAPI"
RUN dotnet build "LinearTestPratico.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LinearTestPratico.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LinearTestPratico.WebAPI.dll"]
