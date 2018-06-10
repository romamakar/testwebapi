FROM microsoft/aspnetcore:2.0 
COPY . /app
WORKDIR /app
RUN["dotnet", "restore"]
RUN["dotnet", "build"]
EXPOSE 5000/tcp
ENTRYPOINT["dotnet", "run"]