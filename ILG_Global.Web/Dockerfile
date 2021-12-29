#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ILG_Global.Web/ILG_Global.Web.csproj", "ILG_Global.Web/"]
COPY ["ILG_Global.DataAccess/ILG_Global.DataAccess.csproj", "ILG_Global.DataAccess/"]
COPY ["ILG_Global.BussinessLogic/ILG_Global.BussinessLogic.csproj", "ILG_Global.BussinessLogic/"]
RUN dotnet restore "ILG_Global.Web/ILG_Global.Web.csproj"
COPY . .
WORKDIR "/src/ILG_Global.Web"
RUN dotnet build "ILG_Global.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ILG_Global.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ILG_Global.Web.dll"]