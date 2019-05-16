using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCookBook.DB.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDBContext>
    {
        public Configuration()
        {

            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;

        }

        protected override void Seed(ApplicationDBContext context)
        {
            var baseDir = System.AppContext.BaseDirectory.Replace("bin", string.Empty).Replace("Debug", string.Empty);

            context.Database.ExecuteSqlCommand(File.ReadAllText(baseDir + "\\Scripts\\seed.sql"));

            base.Seed(context);
        }
    }
}
