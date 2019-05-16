using System;
using System.Collections.Generic;
using WpfCookBook.DB.Dao;
using WpfCookBook.DB.Repository.Base;

namespace WpfCookBook.DB.Repository
{
    public interface IModuleRepository: IRepositoryBase<ModuleDao>
    {

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
    }
}
