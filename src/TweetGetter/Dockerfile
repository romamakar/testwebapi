FROM microsoft/dotnet:2.1-sdk AS build


# copy csproj and restore as distinct layers

COPY *.csproj ./
RUN dotnet restore

# copy everything else and build app
COPY . ./
WORKDIR /app
RUN dotnet publish -c Release -o out

FROM microsoft/dotnet:2.1-aspnetcore-runtime AS runtime
WORKDIR /app
COPY --from=build /app/out ./
EXPOSE 5000/tcp
ENTRYPOINT ["dotnet", "TweetGetter.dll"]