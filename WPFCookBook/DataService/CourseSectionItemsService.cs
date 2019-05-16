using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfCookBook.DB.Dao;
using WpfCookBook.DB.Repository;
using WPFCookBook.DataService.Contracts;

namespace WPFCookBook.DataService
{
    public class CourseSectionItemsService : ICourseSectionItemService
    {
        private ITopicRepository _repo;

        public CourseSectionItemsService(ITopicRepository context)
        {
            _repo = context;
        }

        public IEnumerable<TopicDao> GetAllSectionItems()
        {
            return _repo.GetAll();
        }

        public async Task<TopicDao> GetSectionItemByID(long ID)
        {
            return await _repo.FindItemByCondition( item => item.ID == ID );
        }

        public async Task<TopicDao> GetTopicByName(string name)
        {
            return await _repo.FindItemByCondition(item => item.Title == name);
        }

        public async Task<bool> AddSectionItem(TopicDao item)
        {

            try
            {
                await _repo.Create(item);

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show($"Failed to save document: {e.Message}");
                return false;
            }
        }

        public bool AddTopicToChapterSql(TopicDao topic, long ChapterId)
        {
            try
            {
                var res = _repo.InsertTopicContentWithRawSql(topic.Title, topic.Content, ChapterId, topic.Subtitle);
                return res? true: false;
            }
            catch (Exception e)
            {
                MessageBox.Show($"Failed add section item to topic: {e.Message} - \n {e.InnerException} - \n {e.StackTrace}");
                return false;
            }
        }



        public async Task<bool> DeleteSectionItem(long ID)
        {
            try
            {
                await _repo.Delete( await GetSectionItemByID(ID) );
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> UpdateSectionItem(long ID, TopicDao sect)
        {
            try
            {
                await _repo.Update(sect, ID);
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show($"Failed to update document: {e.Message}");
                return false;
            }
        }
    }
}
