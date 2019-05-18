using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfCookBook.DB.Dao;

namespace WPFCookBook.DataService.Contracts
{
    public interface ICourseSectionService
    {
        IEnumerable<ChapterDao> GetAllSections();
      
        Task<ChapterDao> GetSectionByID(long ID);
        ChapterDao GetSectionByName(string searchStr);
        Task<bool> DeleteSection(long ID);
        Task<bool> UpdateSection(ChapterDao updatedSection);
        bool UpdateChapterSql(ChapterDao UpdatedSect);
        Task<bool> AddSection(ChapterDao sect);
        bool AddSectionWithRawSql(long moduleId, string sectionTitle);
    }
}
