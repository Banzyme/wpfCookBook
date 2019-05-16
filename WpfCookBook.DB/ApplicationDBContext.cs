using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCookBook.DB
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext() : base("WPFCookBookDBDev")
        {
            //Database.SetInitializer(new InitialDBSeed());
        }

        public DbSet<WpfCourseModule> CourseModules { get; set; }
        public DbSet<WpfCourseSection> CourseSections { get; set; }
        public DbSet<WpfCourseSectionItem> CourseSectionItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // Configure relationships
            modelBuilder.Entity<WpfCourseModule>()
                  .HasMany(s => s.ModuleSections);

            modelBuilder.Entity<WpfCourseSection>()
                   .HasMany(s => s.SectionTopics);
        }


    }
}
