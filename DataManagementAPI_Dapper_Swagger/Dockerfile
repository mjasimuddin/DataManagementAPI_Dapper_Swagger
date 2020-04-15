#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-1803 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk-nanoserver-1803 AS build
WORKDIR /src
COPY ["DataManagementAPI_Dapper_Swagger/DataManagementAPI_Dapper_Swagger.csproj", "DataManagementAPI_Dapper_Swagger/"]
RUN dotnet restore "DataManagementAPI_Dapper_Swagger/DataManagementAPI_Dapper_Swagger.csproj"
COPY . .
WORKDIR "/src/DataManagementAPI_Dapper_Swagger"
RUN dotnet build "DataManagementAPI_Dapper_Swagger.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "DataManagementAPI_Dapper_Swagger.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "DataManagementAPI_Dapper_Swagger.dll"]