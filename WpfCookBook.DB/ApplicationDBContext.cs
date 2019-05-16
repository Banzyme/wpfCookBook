using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using WpfCookBook.DB.Dao;

namespace WpfCookBook.DB
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext() : base("WPFCookBookDBDev")
        {
            //Database.SetInitializer(new InitialDBSeed());
        }

        public DbSet<ModuleDao> CourseModules { get; set; }
        public DbSet<ChapterDao> CourseSections { get; set; }
        public DbSet<TopicDao> CourseSectionItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // Configure relationships
            modelBuilder.Entity<ModuleDao>()
                  .HasMany(s => s.ModuleSections);

            modelBuilder.Entity<ChapterDao>()
                   .HasMany(s => s.SectionTopics);
        }


    }
}
