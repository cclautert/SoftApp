FROM  microsoft/dotnet:2.2-aspnetcore-runtime AS final

LABEL version="1.0" maintainer="Cristiano C. Lautert"

WORKDIR /app

COPY ./dist .

ENTRYPOINT ["dotnet", "SoftApp.Taxa.Api.dll"]