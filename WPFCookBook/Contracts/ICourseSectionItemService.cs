using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCookBook.Entities;

namespace WPFCookBook.Contracts
{
    public interface ICourseSectionItemService
    {
        IEnumerable<WpfCourseSectionItem> GetAllSectionItems();
        WpfCourseSectionItem GetSectionItemByID(long ID);
        bool DeleteSectionItem(long ID);
        bool UpdateSectionItem(long ID, WpfCourseSectionItem sect);
        bool AddSectionItem(WpfCourseSectionItem sect);
    }
}
