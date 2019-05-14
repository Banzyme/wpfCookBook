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
    public class CourseSectionService: ICourseSectionService
    {
        private IWpfCourseSectionRepository _repo;

        public CourseSectionService(IWpfCourseSectionRepository repo)
        {
            _repo = repo;
        }

        public bool AddSection(WpfCourseSection sect)
        {
            try
            {
                _repo.Create(sect);
                return true;
            }
            catch (Exception)
            {
                // Todo: Log appropriately;
                return false;
            };
        }

        public bool DeleteSection(long ID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<WpfCourseSection> GetAllSections()
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

        public WpfCourseSection GetSectionByID(long ID)
        {
            try
            {
                return _repo.FindItemByCondition(item => item.ID == ID);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public WpfCourseSection GetSectionByName(string searchStr)
        {
            return _repo.GetSectionWithTopics(searchStr);
        }

        public bool UpdateSection(long ID, WpfCourseSection sect)
        {
            throw new NotImplementedException();
        }
    }
}
