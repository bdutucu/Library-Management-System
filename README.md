# Library Management System

### Pre-requirements

* [.NET8.0+ SDK](https://dotnet.microsoft.com/download/dotnet)
* [Node v18 or 20](https://nodejs.org/en)

### Configurations

The solution comes with a default configuration that works out of the box. However, you may consider to change the following configuration before running your solution:

** Check the `ConnectionStrings` in `appsettings.json` files under the `LibraryManagement.v5.Blazor` and `LibraryManagement.v5.DbMigrator` projects and change it if you need.
**
### Before running the application

* Run `abp install-libs` command on your solution folder to install client-side package dependencies. This step is automatically done when you create a new solution with ABP CLI. However, you should run it yourself if you have first cloned this solution from your source control, or added a new client-side package dependency to your solution.
* Run `LibraryManagement.v5.DbMigrator` to create the initial database. This should be done in the first run. It is also needed if a new database migration is added to the solution later.
