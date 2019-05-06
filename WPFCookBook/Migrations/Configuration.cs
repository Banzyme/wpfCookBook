namespace WPFCookBook.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WPFCookBook.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<WPFCookBook.DataService.ApplicationDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WPFCookBook.DataService.ApplicationDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
           
            var SectItem = new WpfCourseSectionItem()
            {
                ID = new Guid(),
                Title = "Creating a button",
                Subtitle = "Getting started",
                Content = "<Button --attrs/>"
            };
            context.CourseSectionItems.Add(SectItem);

            var sect = new WpfCourseSection()
            {
                ID = new Guid(),
                Title = "Getting started with buttons",
                SectionTopics = new List<WpfCourseSectionItem> { SectItem }
            };
            context.CourseSections.Add(sect);


            IList<WpfCourseModule> defaultModules = new List<WpfCourseModule>();

            defaultModules.Add(new WpfCourseModule()
            {
                ID = new Guid(),
                Name = "Controls"
            });


            context.CourseModules.AddRange(defaultModules);

            base.Seed(context);
        }
    }
}