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
        Task<WpfCourseSection> GetSectionByID(long ID);
        WpfCourseSection GetSectionByName(string searchStr);
        Task<bool> DeleteSection(long ID);
        Task<bool> UpdateSection(WpfCourseSection updatedSection);
        Task<bool> AddSection(WpfCourseSection sect);
        bool AddSectionWithRawSql(long moduleId, string sectionTitle);
    }
}
