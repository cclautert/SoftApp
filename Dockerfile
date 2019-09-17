FROM  microsoft/dotnet:2.2-aspnetcore-runtime AS final

LABEL version="1.0" maintainer="Cristiano"

WORKDIR /app

COPY ./src/SoftApp.Taxa.Api/dist .

ENTRYPOINT ["dotnet", "SoftApp.Taxa.Api.dll"]