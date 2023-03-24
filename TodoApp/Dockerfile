#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

# .net core runtime engine image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TodoApp.csproj", "TodoApp/"]
RUN dotnet restore "TodoApp/TodoApp.csproj"
COPY . "./TodoApp/"
WORKDIR "/src/TodoApp"
RUN dotnet build "TodoApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TodoApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TodoApp.dll"]