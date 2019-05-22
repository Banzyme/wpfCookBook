using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfCookBook.DB.Dao;
using WPFCookBook.Services.DataService.Contracts;

namespace WPFCookBook.CourseContent.Basics
{
    public class FirstTutorialViewModel:ContentViewModelBase
    {
        public FirstTutorialViewModel(ICourseSectionService sectionService, ICourseSectionItemService topics) : base(sectionService, topics)
        {
            LoadInitialData();
        }

        private void LoadInitialData()
        {
            // TODO: Hard coded strings ? REALLY??
            CurrentChapter = _chapterService.GetSectionByName("1.4. Your First WPF Application");
            if (CurrentChapter != null & CurrentChapter.SectionTopics.Count == 0)
            {
                // Add default page and return updated topic
                var result = CreateDefaultPageForChapter(CurrentChapter);
                if (result == true) CurrentChapter = _chapterService.GetSectionByName("1.4. Your First WPF Application");
            }
            _topicList = new ObservableCollection<TopicDao>( CurrentChapter.SectionTopics );
        }
    }
}
