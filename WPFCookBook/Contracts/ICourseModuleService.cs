using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCookBook.Entities;

namespace WPFCookBook.Contracts
{
    public interface ICourseModuleService
    {
        IEnumerable<WpfCourseModule> GetAllModules();
        Task<WpfCourseModule> GetModuleByID(long ID);
        Task<WpfCourseModule> FindModuleByName(string searchStr);
        Task<bool> DeleteModule(long ID);
        Task<bool> UpdateModule(long ID, WpfCourseModule sect);
        Task<bool> AddModule(WpfCourseModule sect);
    }
}
