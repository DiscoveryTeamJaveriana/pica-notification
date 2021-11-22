#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["C3P-Notification-Api/C3P_Notification_Api.csproj", "C3P-Notification-Api/"]
RUN dotnet restore "C3P-Notification-Api/C3P_Notification_Api.csproj"
COPY . .
WORKDIR "/src/C3P-Notification-Api/"
RUN dotnet build "C3P_Notification_Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "C3P_Notification_Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "C3P-Notification-Api.dll"]