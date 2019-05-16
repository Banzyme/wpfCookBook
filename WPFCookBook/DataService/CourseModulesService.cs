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
    public class CourseModulesService : ICourseModuleService
    {
        private readonly ApplicationDBContext _context = new ApplicationDBContext();
        private IWpfCourseModulesRepository _modulesRepo;
        public CourseModulesService(IWpfCourseModulesRepository moduleService)
        {
            _modulesRepo = moduleService;
        }


        public bool DeleteModule(long ID)
        {
            try
            {
                var toDelete = GetModuleByID(ID);
                _modulesRepo.Delete(toDelete);
                return true;
            }
            catch (Exception e)
            {

                MessageBox.Show($"Failed to delete module: {e.Message}");
                return false;
            }
        }

        public IEnumerable<WpfCourseModule> GetAllModules()
        {
            return this._modulesRepo.GetAll();
        }

        public WpfCourseModule GetModuleById(long ID)
        {
            return _context.CourseModules.FirstOrDefault(mod => mod.ID == ID);
        }

        public WpfCourseModule GetModuleByID(long ID)
        {
            try
            {
                var module = _modulesRepo.FindItemByCondition(o => o.ID == ID);
                return module;
            }
            catch (Exception e)
            {
                MessageBox.Show($"Failed to fetch single module: {e.Message}");
                return null;
            };
        }

        public bool AddModule(WpfCourseModule MOD)
        {
            try
            {
                WpfCourseModule newEntry = MOD;
                newEntry.ModuleID = new Guid(); ;
                _modulesRepo.Create(MOD);
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show($"Error saving: {MOD.Name} due to: {e.Message}");
                return false;
            }
        }

        public WpfCourseModule FindModuleByName(string searchStr)
        {
            try
            {
                var result = _modulesRepo.FindItemByCondition(o => o.Name.Contains(searchStr));
                return result;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public bool UpdateModule(long ID, WpfCourseModule updater)
        {
            try
            {
                var newMod = GetModuleById(ID);
                newMod.Name = updater.Name;

                _modulesRepo.Update(newMod, ID);
               
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
