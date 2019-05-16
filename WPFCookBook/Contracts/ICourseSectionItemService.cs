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
        Task<WpfCourseSectionItem> GetSectionItemByID(long ID);
        Task<bool> DeleteSectionItem(long ID);
        Task<bool> UpdateSectionItem(long ID, WpfCourseSectionItem sect);
        Task<bool> AddSectionItem(WpfCourseSectionItem sect);
    }
}
