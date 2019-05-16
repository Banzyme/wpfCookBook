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
        WpfCourseModule GetModuleByID(long ID);
        WpfCourseModule FindModuleByName(string searchStr);
        bool DeleteModule(long ID);
        bool UpdateModule(long ID, WpfCourseModule sect);
        bool AddModule(WpfCourseModule sect);
    }
}
