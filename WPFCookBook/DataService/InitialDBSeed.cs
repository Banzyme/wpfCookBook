using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCookBook.Entities;

namespace WPFCookBook.DataService
{
    public class InitialDBSeed: DropCreateDatabaseAlways<ApplicationDBContext>
    {
        protected override void Seed(ApplicationDBContext context)
        {
            context.Database.ExecuteSqlCommand(
    "insert WpfCourseModule(ModuleID, Name) values (NEWID(), 'Basics(Getting started)')");
            base.Seed(context);
        }
    }
}
