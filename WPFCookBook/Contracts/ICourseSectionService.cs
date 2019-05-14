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
        bool DeleteSection(long ID);
        bool UpdateSection(long ID, WpfCourseSection sect);
        bool AddSection(WpfCourseSection sect);
    }
}
