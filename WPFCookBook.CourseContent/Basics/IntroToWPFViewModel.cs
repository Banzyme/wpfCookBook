using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfCookBook.DB.Dao;
using WPFCookBook.Shared;

namespace WPFCookBook.CourseContent.Basics
{
    public class IntroToWPFViewModel : BindableBase
    {
        private List<TopicDao> _dummyTopics = new List<TopicDao>()
        {
            new TopicDao()
        {
            ID = 1,
            Title = "No title"
        }
        };
        private ObservableCollection<TopicDao> _topicList;

        private TopicDao _newtopic = new TopicDao() { ID=2, Title="NEW TOPIC"};

        public TopicDao NewTopic { get { return _newtopic; } set { _newtopic = value; } }
        public ObservableCollection<TopicDao> TopicsList
        {
            get
            {
                _topicList = new ObservableCollection<TopicDao>(_dummyTopics);
                return _topicList;
            }
            set { _topicList = value;  }
        }
    }
}
