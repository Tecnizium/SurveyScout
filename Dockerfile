FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["SurveyScout/SurveyScout.csproj", "SurveyScout/"]
RUN dotnet restore "SurveyScout/SurveyScout.csproj"
COPY . .
WORKDIR "/src/SurveyScout"
RUN dotnet build "SurveyScout.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SurveyScout.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SurveyScout.dll"]
