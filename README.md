# TweetGetter
[![Build status](https://ci.appveyor.com/api/projects/status/sv2qoijbdxkeursq?svg=true)](https://ci.appveyor.com/project/romamakar/testwebapi)

Welcome to TweetGetter!

This is a simple application for getting tweets from  [this REST API](https://badapi.iqvia.io/swagger/)

Just enter dates and times into pickers and click "Get tweets"

## Installation

1. Make sure that have installed [aspnetcore2.0](https://www.microsoft.com/net/download/windows)
2. Clone this project
3. Go to `src\TweetGetter`
3. Run 
```
dotnet restore
dotnet build
dotnet run
```
4. Your app will be available on http://localhost:5000

## Docker
[![Codefresh build status]( https://g.codefresh.io/api/badges/build?repoOwner=romamakar&repoName=testwebapi&branch=master&pipelineName=testwebapi&accountName=romamakar_marketplace&type=cf-1)]( https://g.codefresh.io/repositories/romamakar/testwebapi/builds?filter=trigger:build;branch:master;service:5b1ed84c29b6d0e4ea24e526~testwebapi)

1. Install [docker](https://www.docker.com/community-edition)
2. Clone this project
3. Go to `src\TweetGetter`
4. Run 
```
docker build -t tweetgetter
docker run -d -p 5000:5000 tweetgetter
```
5. Your app will be available on http://localhost:5000
