using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public WpfCourseSectionItem GetSectionItemByID(long ID)
        {
            return _repo.FindItemByCondition( item => item.ID == ID );
        }

        public bool AddSectionItem(WpfCourseSectionItem item)
        {

            try
            {
                _repo.Create(item);

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteSectionItem(long ID)
        {
            try
            {
                _repo.Delete( GetSectionItemByID(ID) );
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool UpdateSectionItem(long ID, WpfCourseSectionItem sect)
        {
            try
            {
                _repo.Update(sect, ID);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
