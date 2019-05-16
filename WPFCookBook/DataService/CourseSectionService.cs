using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfCookBook.DB.Dao;
using WpfCookBook.DB.Repository;
using WPFCookBook.DataService.Contracts;

namespace WPFCookBook.DataService
{
    public class CourseSectionService: ICourseSectionService
    {
        private IChapterRepository _repo;

        public CourseSectionService(IChapterRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> AddSection(ChapterDao sect)
        {
            try
            {
                await _repo.Create(sect);
                return true;
            }
            catch (Exception e)
            {
                // Todo: Log appropriately;
                MessageBox.Show($"Failed to add section: {e.Message}");
                return false;
            };
        }

        public bool AddSectionWithRawSql(long moduleId, string sectionTitle)
        {
            try
            {
                _repo.InsertSectionWithRawSql(moduleId, sectionTitle);
                return true;
            }
            catch (Exception e)
            {
                // Todo: Log appropriately;
                MessageBox.Show($"Failed to add section with raw sql: {e.Message}");
                return false;
            };
        }

        public async Task<bool> DeleteSection(long ID)
        {
            try
            {
                var itemToDelete = await _repo.FindItemByCondition(item => item.ID == ID);
                await _repo.Delete(itemToDelete);
                return true;
            }
            catch (Exception e)
            {

                MessageBox.Show($"Failed to delete chapter: {e.Message}. \n {e.StackTrace}");
                return false;
            }
        }

        public IEnumerable<ChapterDao> GetAllSections()
        {
            try
            {
                return _repo.GetAll();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ChapterDao> GetSectionByID(long ID)
        {
            try
            {
                return await _repo.FindItemByCondition(item => item.ID == ID);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public  ChapterDao GetSectionByName(string searchStr)
        {
            return _repo.GetTopicsForChapter(searchStr);
        }

        public async Task<bool> UpdateSection(ChapterDao UpdatedSect)
        {
            try
            {
                await _repo.Update(UpdatedSect, UpdatedSect.ID);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
