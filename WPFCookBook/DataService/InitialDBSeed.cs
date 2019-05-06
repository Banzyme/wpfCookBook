using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCookBook.Entities;

namespace WPFCookBook.DataService
{
    public class InitialDBSeed: CreateDatabaseIfNotExists<ApplicationDBContext>
    {
        protected override void Seed(ApplicationDBContext context)
        {
            Console.WriteLine("I am not called 2");
            var SectItem = new WpfCourseSectionItem()
            {
                ID = new Guid(),
                Title = "Creating a button",
                Subtitle = "Getting started",
                Content = "<Button --attrs/>"
            };
            context.CourseSectionItems.Add(SectItem);

            var sect = new WpfCourseSection() {
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
