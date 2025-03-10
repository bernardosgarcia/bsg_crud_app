FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /src

ENV ASPNETCORE_HTTP_PORTS=5100
EXPOSE 5100 5101

ENV TZ=America/Sao_Paulo
RUN ln -snf /usr/share/zoneinfo/$TZ /etc/localtime && echo $TZ > /etc/timezone

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY ["bsg_crud_app.sln", "./"]
COPY ["bsg_crud_app/bsg_crud_app.csproj", "bsg_crud_app/"]

WORKDIR /src/bsg_crud_app
RUN dotnet restore

COPY . .

RUN dotnet build -c Release -o /app/build

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app

COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "bsg_crud_app.dll"]
