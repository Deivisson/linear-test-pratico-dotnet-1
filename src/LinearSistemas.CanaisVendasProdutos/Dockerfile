#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/LinearSistemas.CanaisVendasProdutos/LinearSistemas.CanaisVendasProdutos.API.csproj", "src/LinearSistemas.CanaisVendasProdutos/"]
COPY ["src/CanaisVendas.Application/LinearSistemas.CanaisVendas.Application.csproj", "src/CanaisVendas.Application/"]
COPY ["src/LinearSistemas.CanaisVendas.Domain/LinearSistemas.CanaisVendas.Domain.csproj", "src/LinearSistemas.CanaisVendas.Domain/"]
COPY ["src/LinearSistemas.CanaisVendas.Infra/LinearSistemas.CanaisVendas.Infra.csproj", "src/LinearSistemas.CanaisVendas.Infra/"]
RUN dotnet restore "src/LinearSistemas.CanaisVendasProdutos/LinearSistemas.CanaisVendasProdutos.API.csproj"
COPY . .
WORKDIR "/src/src/LinearSistemas.CanaisVendasProdutos"
RUN dotnet build "LinearSistemas.CanaisVendasProdutos.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LinearSistemas.CanaisVendasProdutos.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LinearSistemas.CanaisVendasProdutos.API.dll"]