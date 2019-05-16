using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFCookBook.Contracts;
using WPFCookBook.DataService.Repository;
using WPFCookBook.Entities;

namespace WPFCookBook.DataService
{
    public class CourseSectionItemsService : ICourseSectionItemService
    {
        private  IWpfCourseSectionItemRepo _repo;

        public CourseSectionItemsService(IWpfCourseSectionItemRepo context)
        {
            _repo = context;
        }

        public IEnumerable<WpfCourseSectionItem> GetAllSectionItems()
        {
            return _repo.GetAll();
        }

        public async Task<WpfCourseSectionItem> GetSectionItemByID(long ID)
        {
            return await _repo.FindItemByCondition( item => item.ID == ID );
        }

        public async Task<bool> AddSectionItem(WpfCourseSectionItem item)
        {

            try
            {
                await _repo.Create(item);

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show($"Failed to save document: {e.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteSectionItem(long ID)
        {
            try
            {
                await _repo.Delete( await GetSectionItemByID(ID) );
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> UpdateSectionItem(long ID, WpfCourseSectionItem sect)
        {
            try
            {
                await _repo.Update(sect, ID);
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show($"Failed to update document: {e.Message}");
                return false;
            }
        }
    }
}
