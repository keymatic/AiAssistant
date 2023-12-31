#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Key.AiAssistant.API/Key.AiAssistant.API.csproj", "Key.AiAssistant.API/"]
COPY ["Key.AiAssistant.Application/Key.AiAssistant.Application.csproj", "Key.AiAssistant.Application/"]
COPY ["Key.AiAssistant.Domain/Key.AiAssistant.Domain.csproj", "Key.AiAssistant.Domain/"]
COPY ["Key.AiAssistant.OpenAI/Key.AiAssistant.ChatGPT.csproj", "Key.AiAssistant.OpenAI/"]
COPY ["Key.AiAssistant.Store/Key.AiAssistant.Store.csproj", "Key.AiAssistant.Store/"]
RUN dotnet restore "Key.AiAssistant.API/Key.AiAssistant.API.csproj"
COPY . .
WORKDIR "/src/Key.AiAssistant.API"
RUN dotnet build "Key.AiAssistant.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Key.AiAssistant.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Key.AiAssistant.API.dll"]