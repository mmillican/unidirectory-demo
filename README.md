# University Directory - Sample App

This app is a demo application showing a simple ASP.NET Core Web API and an Angular CLI front-end.

Data Source: https://github.com/Hipo/university-domains-list-api (no auth needed)

## Running the app

To run the API:

```
$ cd UniversityApi
$ dotnet restore
$ dotnet build # optional as `run` will also build the project

$ dotnet run
```

Running the Front-end

```
$ cd UniversityWeb
$ ng build
$ ng serve
```

> See `README` in UniversityWeb directory for more about running Angular CLI projects.

## Hosting

The API is has a `serverless.template` to be deployed to AWS Lambda and API Gateway.

The front-end was tested to work while hosted in an S3 bucket set up for "static site hosting".