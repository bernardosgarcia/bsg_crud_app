# Definir versão do SDK e runtime como argumentos
ARG DOTNET_SDK_VERSION=9.0
ARG DOTNET_RUNTIME_VERSION=9.0

# Imagem base do runtime
FROM mcr.microsoft.com/dotnet/aspnet:${DOTNET_RUNTIME_VERSION} AS base
WORKDIR /app

# Expor portas usadas pela aplicação
ENV ASPNETCORE_HTTP_PORTS=5100
EXPOSE 5100 5101

# Definir fuso horário
ENV TZ=America/Sao_Paulo
RUN ln -snf /usr/share/zoneinfo/$TZ /etc/localtime && echo $TZ > /etc/timezone

# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:${DOTNET_SDK_VERSION} AS build
WORKDIR /src

# Copiar apenas os arquivos da solução e do projeto para otimizar cache
COPY ["renault.risk.manager.sln", "./"]
COPY ["bsg_crud_app/bsg_crud_app.csproj", "bsg_crud_app/"]

# Restaurar dependências antes de copiar o restante do código
WORKDIR /src/bsg_crud_app
RUN dotnet restore

# Copiar todo o código da aplicação
COPY . .

# Compilar o código
RUN dotnet build -c Release -o /app/build

# Etapa de publicação
FROM build AS publish
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

# Imagem final
FROM base AS final
WORKDIR /app

# Copiar arquivos publicados para a imagem final
COPY --from=publish /app/publish .

# Definir ponto de entrada
ENTRYPOINT ["dotnet", "bsg_crud_app.dll"]
