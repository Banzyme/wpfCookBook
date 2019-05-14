using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCookBook.Entities;

namespace WPFCookBook.DataService.Repository
{
    public interface IWpfCourseSectionItemRepo: IRepositoryBase<WpfCourseSectionItem> { }
    public class WpfCourseSectionItemRepo : RepositoryBase<WpfCourseSectionItem>, IWpfCourseSectionItemRepo
    {
        public WpfCourseSectionItemRepo(ApplicationDBContext db) : base(db)
        {
        }
    }
}
