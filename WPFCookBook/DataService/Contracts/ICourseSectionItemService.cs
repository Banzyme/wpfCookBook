using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WpfCookBook.DB.Dao;

namespace WPFCookBook.DataService.Contracts
{
    public interface ICourseSectionItemService
    {
        IEnumerable<TopicDao> GetAllSectionItems();
        Task<TopicDao> GetSectionItemByID(long ID);
        Task<bool> DeleteSectionItem(long ID);
        Task<bool> UpdateSectionItem(long ID, TopicDao sect);
        Task<bool> AddSectionItem(TopicDao sect);
    }
}
