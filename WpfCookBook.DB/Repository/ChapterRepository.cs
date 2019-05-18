using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfCookBook.DB.Dao;
using WpfCookBook.DB.Models;
using WpfCookBook.DB.Repository.Base;

namespace WpfCookBook.DB.Repository
{
    public interface IChapterRepository : IRepositoryBase<ChapterDao>
    {
        ChapterDao GetTopicsForChapter(string chapter);
        bool InsertSectionWithRawSql(long moduleId, string newChapter);
        IEnumerable<ChapterModel> GetChaptersWithModuleIds();
    }

    public class ChapterRepository : RepositoryBase<ChapterDao>, IChapterRepository
    {
        public ChapterRepository(ApplicationDBContext db) : base(db)
        {
        }


        /// <summary>
        /// Retrives all topics for a given chapter
        /// </summary>
        /// <param name="Chapter name"></param>
        /// <returns>Chapter object with all associated topics</returns>
        public ChapterDao GetTopicsForChapter(string chapter)
        {
            return _db.CourseSections.Include("SectionTopics").Include("ParentModule").SingleOrDefault(x => x.Title.Contains(chapter));
        }

        /// <summary>
        /// Add a new chapter to module
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="newChapter"></param>
        /// <returns>Returns true if query is successful</returns>
        public bool InsertSectionWithRawSql(long moduleId, string newChapter)
        {
            Guid randomGuid = new Guid();
            string sql = "insert ChapterDao(SectionID, Title, ParentModule_ID) values({0}, {1}, {2})";
            int rowsAffected = _db.Database.ExecuteSqlCommand(sql, randomGuid, newChapter, moduleId);

            return rowsAffected == 0 ? false : true;
        }

        public IEnumerable<ChapterModel> GetChaptersWithModuleIds()
        {
            string sql = "select * from ChapterDao";
            //var result = _db.Database.SqlQuery<IEnumerable<ChapterModel>>(sql).ToList();
            var test = _db.CourseSections.ToList();

            return null;
        }

    }
}
