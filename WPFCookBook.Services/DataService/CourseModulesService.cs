using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using WpfCookBook.DB.Dao;
using WpfCookBook.DB.Repository;
using WPFCookBook.Services.DataService.Contracts;

namespace WPFCookBook.Services.DataService
{
    public class CourseModulesService : ICourseModuleService
    {
        private IModuleRepository _modulesRepo;
        public CourseModulesService(IModuleRepository moduleService)
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

                MessageBox.Show($"Failed to delete module: {e.Message} \n \n {e.InnerException} \n \n {e.StackTrace}");
                return false;
            }
        }

        public IEnumerable<ModuleDao> GetAllModules()
        {
            return _modulesRepo.GetAll();
        }

        public Task<List<ModuleDao>> GetAllModulesAsync()
        {
            return _modulesRepo.GetAllAsync();
        }

        public async Task<ModuleDao> GetModuleByID(long ID)
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

        public async Task<bool> AddModule(ModuleDao MOD)
        {
            try
            {
                ModuleDao newEntry = MOD;
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

        public async Task<ModuleDao> FindModuleByName(string searchStr)
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

        public async Task<bool> UpdateModule(ModuleDao updatedModule)
        {
            try
            {
                await _modulesRepo.Update(updatedModule, updatedModule.ID);

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
