FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["ApiEnterpriseDemo/ApiEnterpriseDemo.csproj", "ApiEnterpriseDemo/"]
RUN dotnet restore "ApiEnterpriseDemo/ApiEnterpriseDemo.csproj"
COPY . .
WORKDIR "/src/ApiEnterpriseDemo"
RUN dotnet build "ApiEnterpriseDemo.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ApiEnterpriseDemo.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ApiEnterpriseDemo.dll"]