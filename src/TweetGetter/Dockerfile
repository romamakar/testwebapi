FROM microsoft/dotnet:2-aspnetcore-runtime 
COPY . /app
WORKDIR /app
RUN["dotnet", "restore"]
RUN["dotnet", "build"]
EXPOSE 5000/tcp
ENTRYPOINT["dotnet", "run"]
