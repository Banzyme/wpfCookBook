using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfCookBook.DB.Dao;

namespace WPFCookBook.DataService.Contracts
{
    public interface ICourseModuleService
    {
        IEnumerable<ModuleDao> GetAllModules();
        Task<ModuleDao> GetModuleByID(long ID);
        Task<ModuleDao> FindModuleByName(string searchStr);
        Task<bool> DeleteModule(long ID);
        Task<bool> UpdateModule(long ID, ModuleDao sect);
        Task<bool> AddModule(ModuleDao sect);
    }
}
