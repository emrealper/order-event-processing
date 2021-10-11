#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["OrderConsumerQueryingService.Api/OrderConsumerQueryingService.Api.csproj", "OrderConsumerQueryingService.Api/"]
COPY ["Persistance/Persistance.csproj", "Persistance/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["Application/Application.csproj", "Application/"]
COPY ["Infrastructure/Infrastructure.csproj", "Infrastructure/"]
RUN dotnet restore "OrderConsumerQueryingService.Api/OrderConsumerQueryingService.Api.csproj"
COPY . .
WORKDIR "/src/OrderConsumerQueryingService.Api"
RUN dotnet build "OrderConsumerQueryingService.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OrderConsumerQueryingService.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OrderConsumerQueryingService.Api.dll"]