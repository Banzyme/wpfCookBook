using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCookBook.Entities;

namespace WPFCookBook.Contracts
{
    public interface ICourseSectionService
    {
        IEnumerable<WpfCourseSection> GetAllSections();
        WpfCourseSection GetSectionByID(long ID);
        WpfCourseSection GetSectionByName(string searchStr);
        bool DeleteSection(long ID);
        bool UpdateSection(long ID, WpfCourseSection sect);
        bool AddSection(WpfCourseSection sect);
        bool AddSectionWithRawSql(long moduleId, string sectionTitle);
    }
}
