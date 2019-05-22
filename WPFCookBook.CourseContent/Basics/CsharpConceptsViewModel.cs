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
    public class CsharpConceptsViewModel:ContentViewModelBase
    {
        public CsharpConceptsViewModel(ICourseSectionService sectionService, ICourseSectionItemService topics) : base(sectionService, topics)
        {
            LoadInitialData();
        }

        private void LoadInitialData()
        {
            // TODO: Hard coded strings ? REALLY??
            CurrentChapter = _chapterService.GetSectionByName("1.3. C# Concepts");
            if (CurrentChapter != null & CurrentChapter.SectionTopics.Count == 0)
            {
                // Add default page and return updated topic
                var result = CreateDefaultPageForChapter(CurrentChapter);
                if (result == true) CurrentChapter = _chapterService.GetSectionByName("1.3. C# Concepts");
            }

            _topicList = new ObservableCollection<TopicDao>( CurrentChapter.SectionTopics );
        }
    }
}
