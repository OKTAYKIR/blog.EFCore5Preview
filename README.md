# Entity Framework Core 5 Preview - Samples
EF Core 5 Samples include docker-compose file

## 📦 Stack
* .Net Core 3.1
* [EF Core 5 Preview](https://docs.microsoft.com/en-us/ef/core/)

## 🚀 Run Locally
* There's a [docker-compose](build/docker-compose.yml) file and you can use the following command to launch Sql Server container. 
```
$ docker-compose up -d
```

* Uninstall and install dotnet-ef cli tool from nuget package manager
```
dotnet tool uninstall --global dotnet-ef
dotnet tool install --global dotnet-ef --version 5.0.0-preview.2.20120.8
```

* Install EF Core 5.0 Preview 1 from nuget package manager
```
Install-Package Microsoft.EntityFrameworkCore -Version 5.0.0-preview.2.20120.8
```

* Install EntityFrameworkCore.SqlServer from nuget package manager
```
Install-Package Microsoft.EntityFrameworkCore.SqlServer -Version 5.0.0-preview.2.20120.8
```
* Execute database migrations
```
dotnet ef migrations add InitialMigration
dotnet ef database update
```

## Show your support
Please ⭐️ this repository if this project helped you!

## 📝 License
MIT License
