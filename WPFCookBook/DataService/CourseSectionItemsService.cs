using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCookBook.Entities;

namespace WPFCookBook.DataService
{
    public class CourseSectionItemsService
    {
        private readonly ApplicationDBContext _context = new ApplicationDBContext();

        public CourseSectionItemsService()
        {
        }

        public IEnumerable<WpfCourseSection> GetAllSections()
        {
            return _context.CourseSections;
        }

        public WpfCourseSection GetSectionById(long ID)
        {
            return _context.CourseSections.FirstOrDefault(mod => mod.ID == ID);
        }

        public bool SaveNewSection(WpfCourseSection MOD)
        {
            var newEntry = new WpfCourseSection()
            {
                Title = MOD.Title
            };
            _context.CourseSections.Add(newEntry);
            _context.SaveChangesAsync();

            return true;
        }

        public bool UpdateSection(long ID, WpfCourseSection updater)
        {
            var newSect = GetSectionById(ID);
            newSect.Title = updater.Title;
            _context.SaveChangesAsync();
            return true;
        }
    }
}
