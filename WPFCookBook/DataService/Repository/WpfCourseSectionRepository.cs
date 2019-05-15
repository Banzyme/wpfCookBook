using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCookBook.Entities;

namespace WPFCookBook.DataService.Repository
{
    public interface IWpfCourseSectionRepository : IRepositoryBase<WpfCourseSection>
    {
        bool InsertSectionWithRawSql(long moduleId, string newChapter);
        WpfCourseSection GetSectionWithTopics(string searchStr);
    }
    public class WpfCourseSectionRepository : RepositoryBase<WpfCourseSection>, IWpfCourseSectionRepository
    {
        public WpfCourseSectionRepository(ApplicationDBContext db) : base(db)
        {
        }

        public WpfCourseSection GetSectionWithTopics(string searchStr)
        {
            return _db.CourseSections.Include("SectionTopics").SingleOrDefault(x => x.Title.Contains(searchStr));
        }

        public bool InsertSectionWithRawSql(long moduleId, string newChapter)
        {
            Guid randomGuid = new Guid();
            string sql = "insert WpfCourseSection(SectionID, Title, WpfCourseModule_ID) values({0}, {1}, {2})";
            int rowsAffected = _db.Database.ExecuteSqlCommand(sql, randomGuid, newChapter, moduleId );

            return rowsAffected == 0 ? false : true;
        }
    }
}
