using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCookBook.Entities;

namespace WPFCookBook.DataService
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(): base("WPFCookBookDBDev")
        {
            Database.SetInitializer<ApplicationDBContext>(new InitialDBSeed());
        }

        public DbSet<WpfCourseModule> CourseModules { get; set; }
        public DbSet<WpfCourseSection> CourseSections { get; set; }
        public DbSet<WpfCourseSectionItem> CourseSectionItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            
        }

        
    }
}
