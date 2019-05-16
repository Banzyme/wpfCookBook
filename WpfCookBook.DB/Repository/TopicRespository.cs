using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfCookBook.DB.Dao;
using WpfCookBook.DB.Repository.Base;

namespace WpfCookBook.DB.Repository
{
    public interface ITopicRepository: IRepositoryBase<TopicDao>
    {

    }
    public class TopicRespository: RepositoryBase<TopicDao>, ITopicRepository
    {

        public TopicRespository(ApplicationDBContext db): base(db)
        {
        }
    }
}
