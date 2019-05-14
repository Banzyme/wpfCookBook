using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCookBook.Entities;

namespace WPFCookBook.DataService.Repository
{
    public interface IWpfCourseModulesRepository: IRepositoryBase<WpfCourseModule> { }
    public class WpfCourseModulesRepository : RepositoryBase<WpfCourseModule>, IWpfCourseModulesRepository
    {
        public WpfCourseModulesRepository(ApplicationDBContext db) : base(db)
        {
        }
    }
}
