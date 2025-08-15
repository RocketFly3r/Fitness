FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ./src/Fitness/Fitness.csproj ./src/Fitness/
COPY ./src/Fitness.Api/Fitness.Api.csproj ./src/Fitness.Api/
COPY ./src/Fitness.Application/Fitness.Application.csproj ./src/Fitness.Application/
COPY ./src/Fitness.Domain/Fitness.Domain.csproj ./src/Fitness.Domain/
COPY ./src/Fitness.Infrastructure/Fitness.Infrastructure.csproj ./src/Fitness.Infrastructure/

RUN dotnet restore ./src/Fitness/Fitness.csproj

COPY ./src ./src

RUN dotnet publish ./src/Fitness/Fitness.csproj -c $BUILD_CONFIGURATION -o /app/publish --no-restore /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish ./

ENTRYPOINT ["dotnet", "Fitness.dll"]