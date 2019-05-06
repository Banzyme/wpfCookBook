namespace WPFCookBook.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using WPFCookBook.Entities;
    using static System.Net.Mime.MediaTypeNames;

    internal sealed class Configuration : DbMigrationsConfiguration<WPFCookBook.DataService.ApplicationDBContext>
    {
        public Configuration()
        {
            
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(WPFCookBook.DataService.ApplicationDBContext context)
        {

            var baseDir = System.AppContext.BaseDirectory.Replace("bin", string.Empty).Replace("Debug", string.Empty);

            context.Database.ExecuteSqlCommand(File.ReadAllText(baseDir + "\\DataService\\scripts\\seed.sql"));

            base.Seed(context);
        }
    }
}
