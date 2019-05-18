using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using WpfCookBook.DB.Dao;
using WpfCookBook.DB.Repository.Base;

namespace WpfCookBook.DB.Repository
{
    public interface IModuleRepository: IRepositoryBase<ModuleDao>
    {
        Task<List<ModuleDao>> GetAllAsync();
    }

    public class ModuleRepository : RepositoryBase<ModuleDao>, IModuleRepository
    {
        public ModuleRepository(ApplicationDBContext db) : base(db)
        {
        }

        public override IEnumerable<ModuleDao> GetAll()
        {
            return _db.CourseModules.Include("ModuleSections");
        }

        public override async Task<List<ModuleDao>> GetAllAsync()
        {
            return await _db.CourseModules.Include("ModuleSections").ToListAsync();
        }
    }
}
