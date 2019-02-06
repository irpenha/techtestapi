#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["TechTestApi/TechTestApi.csproj", "TechTestApi/"]
RUN dotnet restore "TechTestApi/TechTestApi.csproj"
COPY . .
WORKDIR "/src/TechTestApi"
RUN dotnet build "TechTestApi.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "TechTestApi.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TechTestApi.dll"]