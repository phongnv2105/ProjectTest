namespace WebApplication_Test.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ConnectDB : DbContext
    {
        // Your context has been configured to use a 'ConnectDB' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'WebApplication_Test.Models.ConnectDB' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ConnectDB' 
        // connection string in the application configuration file.
        public ConnectDB()
            : base("name=ConnectDB")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ConnectDB, Migrations.Configuration>("ConnectDB"));
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<User> Users { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}