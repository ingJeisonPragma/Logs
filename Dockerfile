#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 7076
ENV ASPNETCORE_URLS=http://*:7076

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["./Logs.Api/Logs.Api.csproj", "Logs.Api/"]
COPY ["./Logs.DataAccess/Logs.DataAccess.csproj", "Logs.DataAccess/"]
COPY ["./Logs.DataAccess.Interface/Logs.DataAccess.Interface.csproj", "Logs.DataAccess.Interface/"]
COPY ["./Logs.Domain.Business/Logs.Domain.Business.csproj", "Logs.Domain.Business/"]
COPY ["./Logs.Domain.Services.Interface/Logs.Domain.Services.Interface.csproj", "Logs.Domain.Services.Interface/"]
COPY ["./Logs.Domain.Services/Logs.Domain.Services.csproj", "Logs.Domain.Services/"]
RUN dotnet restore "Logs.Api/Logs.Api.csproj"
COPY . .
WORKDIR "/src/Logs.Api"
RUN dotnet build "Logs.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Logs.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Logs.Api.dll"]