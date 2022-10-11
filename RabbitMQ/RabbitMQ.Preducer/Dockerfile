#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["RabbitMQ.Preducer/RabbitMQ.Preducer.csproj", "RabbitMQ.Preducer/"]
RUN dotnet restore "RabbitMQ.Preducer/RabbitMQ.Preducer.csproj"
COPY . .
WORKDIR "/src/RabbitMQ.Preducer"
RUN dotnet build "RabbitMQ.Preducer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RabbitMQ.Preducer.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RabbitMQ.Preducer.dll"]