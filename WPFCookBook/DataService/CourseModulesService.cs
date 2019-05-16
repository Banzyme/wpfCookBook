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


        public async Task<bool> DeleteModule(long ID)
        {
            try
            {
                var toDelete = await GetModuleByID(ID);
                await _modulesRepo.Delete(toDelete);
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

        public async Task<WpfCourseModule> GetModuleByID(long ID)
        {
            try
            {
                var module = _modulesRepo.FindItemByCondition(o => o.ID == ID);
                return await module;
            }
            catch (Exception e)
            {
                MessageBox.Show($"Failed to fetch single module: {e.Message}");
                return null;
            };
        }

        public async Task<bool> AddModule(WpfCourseModule MOD)
        {
            try
            {
                WpfCourseModule newEntry = MOD;
                newEntry.ModuleID = new Guid(); ;
                await _modulesRepo.Create(MOD);
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show($"Error saving: {MOD.Name} due to: {e.Message}");
                return false;
            }
        }

        public async Task<WpfCourseModule> FindModuleByName(string searchStr)
        {
            try
            {
                var result = await _modulesRepo.FindItemByCondition(o => o.Name.Contains(searchStr));
                return result;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<bool> UpdateModule(long ID, WpfCourseModule updater)
        {
            try
            {
                var newMod =await GetModuleByID(ID);
                newMod.Name = updater.Name;

                await _modulesRepo.Update(newMod, ID);
               
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
