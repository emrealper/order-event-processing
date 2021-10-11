#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["OrderProducer.Api/OrderProducer.Api.csproj", "OrderProducer.Api/"]
COPY ["Application/Application.csproj", "Application/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["Infrastructure/Infrastructure.csproj", "Infrastructure/"]
RUN dotnet restore "OrderProducer.Api/OrderProducer.Api.csproj"
COPY . .
WORKDIR "/src/OrderProducer.Api"
RUN dotnet build "OrderProducer.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OrderProducer.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OrderProducer.Api.dll"]