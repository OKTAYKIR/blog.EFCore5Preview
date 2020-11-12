# Entity Framework Core 5 - Samples
EF Core 5 Samples include docker-compose file

[Medium blog](https://medium.com/@Oktaykir)

## 📦 Stack
* .Net Core 3.1
* [EF Core 5](https://docs.microsoft.com/en-us/ef/core/)

## 🚀 Run Locally
* There's a [docker-compose](build/docker-compose.yml) file and you can use the following command to launch Sql Server container. 
```
$ docker-compose up -d
```

* Uninstall and install dotnet-ef cli tool from nuget package manager
```
dotnet tool uninstall --global dotnet-ef
dotnet tool install --global dotnet-ef --version 5.0.0-preview.7.20365.15
```

* Install EF Core 5.0 Preview 7 from nuget package manager
```
Install-Package Microsoft.EntityFrameworkCore -version 5.0.0-preview.7.20365.15
```

* Install EntityFrameworkCore.SqlServer from nuget package manager
```
Install-Package Microsoft.EntityFrameworkCore.SqlServer -version 5.0.0-preview.7.20365.15
```
* Execute database migrations and scaffolding
```
dotnet ef dbcontext scaffold "Server=127.0.0.1;Initial Catalog=master;User=sa;Password=Pass@word;" Microsoft.EntityFrameworkCore.SqlServer --context-namespace "My.Context" --namespace "EFCore5Preview1.Context" --project d:\Repositories\blog\EFCore5Preview\EFCore5Preview1\EFCore5Preview1.csproj

dotnet ef migrations add InitialCreate --namespace "EFCore5Preview1.Context" --project d:\Repositories\blog\EFCore5Preview\EFCore5Preview1\EFCore5Preview1.csproj --verbose --dev

dotnet ef database update --connection "Server=127.0.0.1;Initial Catalog=master;User=sa;Password=Pass@word;" --project d:\Repositories\blog\EFCore5Preview\EFCore5Preview1\EFCore5Preview1.csproj
```

## Show your support
Please ⭐️ this repository if this project helped you!

## 📝 License
MIT License
