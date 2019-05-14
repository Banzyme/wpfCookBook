using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCookBook.Contracts;
using WPFCookBook.Entities;

namespace WPFCookBook.DataService
{
    public class CourseModulesService: ICourseModuleService
    {
        private readonly ApplicationDBContext _context = new ApplicationDBContext();
        public CourseModulesService()
        {
        }

        public bool AddModule(WpfCourseModule sect)
        {
            throw new NotImplementedException();
        }

        public bool DeleteModule(long ID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<WpfCourseModule> GetAllModules()
        {
            return _context.CourseModules;
        }

        public WpfCourseModule GetModuleById(long ID)
        {
            return _context.CourseModules.FirstOrDefault(mod => mod.ID == ID);
        }

        public WpfCourseModule GetModuleByID(long ID)
        {
            throw new NotImplementedException();
        }

        public bool SaveNewModule(WpfCourseModule MOD)
        {
            var newEntry = new WpfCourseModule()
            {
                Name = MOD.Name
            };
            _context.CourseModules.Add(newEntry);
            _context.SaveChangesAsync();

            return true;
        }

        public bool UpdateModule(long ID, WpfCourseModule updater)
        {
            var newMod = GetModuleById(ID);
            newMod.Name = updater.Name;
            _context.SaveChangesAsync();
            return true;
        }
    }
}
