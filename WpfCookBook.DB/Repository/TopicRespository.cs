using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfCookBook.DB.Dao;
using WpfCookBook.DB.Repository.Base;

namespace WpfCookBook.DB.Repository
{
    public interface ITopicRepository : IRepositoryBase<TopicDao>
    {
        bool InsertTopicContentWithRawSql(string title, string content, long sectionId, string subTitle = "Not provided");
    }
    public class TopicRespository : RepositoryBase<TopicDao>, ITopicRepository
    {

        public TopicRespository(ApplicationDBContext db) : base(db)
        {
        }

        public bool InsertTopicContentWithRawSql(string title, string content, long sectionId, string subTitle = "Not provided")
        {
            string sql = "insert TopicDao(SectionItemID, Title, Subtitle, Content, ChapterDao_ID) values({0}, {1}, {2}, {3}, {4})";


            Guid randomGuid = new Guid();

            int rowsAffected = _db.Database.ExecuteSqlCommand(sql, randomGuid, title, subTitle, content, sectionId);

            return rowsAffected > 0 ? true : false;

        }
    }
}
