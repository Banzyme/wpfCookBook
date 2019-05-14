using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCookBook.Entities;

namespace WPFCookBook.DataService.Repository
{
    public interface IWpfCourseSectionRepository: IRepositoryBase<WpfCourseSection> { WpfCourseSection GetSectionWithTopics(string searchStr); }
    public class WpfCourseSectionRepository : RepositoryBase<WpfCourseSection>, IWpfCourseSectionRepository
    {
        public WpfCourseSectionRepository(ApplicationDBContext db) : base(db)
        {
        }

        public WpfCourseSection GetSectionWithTopics(string searchStr)
        {
            return _db.CourseSections.Include("SectionTopics").SingleOrDefault(x => x.Title.Contains(searchStr));
        }
    }
}
