# TweetGetter
[![Build status](https://ci.appveyor.com/api/projects/status/sv2qoijbdxkeursq?svg=true)](https://ci.appveyor.com/project/romamakar/testwebapi)

Welcome to TweetGetter!

This is a simple application for getting tweets from  [this REST API](https://badapi.iqvia.io/swagger/)

Just enter dates and times into pickers and click "Get tweets"

##Instalation

1. Make sure that have installed [aspnetcore2.0](https://www.microsoft.com/net/download/windows)
2. Clone this project
3. Go to 'src\TweetGetter'
3. Run 
```
dotnet restore
dotnet build
dotnet run
```
4. Your app will be available on http://localhost:5000

##Docker

1. Install [docker] (https://www.docker.com/community-edition)
2. Clone this project
3. Go to 'src\TweetGetter'
4. Run 
```
docker build -t tweetgetter
docker run -d -p 5000:5000 tweetgetter
```
5. Your app will be available on http://localhost:5000
