using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfCookBook.DB.Dao;
using WPFCookBook.Services.DataService.Contracts;
using WPFCookBook.Shared.Constants;

namespace WPFCookBook.CourseContent.DataBinding
{
    public class AsyncBindingViewModel: ContentViewModelBase
    {
        public AsyncBindingViewModel(ICourseSectionService sectionService, ICourseSectionItemService topics) : base(sectionService, topics)
        {
            LoadInitialData();
        }

        private void LoadInitialData()
        {
            CurrentChapter = _chapterService.GetSectionByName(CourseCatalog.ASYNC_BINDING);
            if (CurrentChapter != null & CurrentChapter.SectionTopics.Count == 0)
            {
                // Add default page and return updated topic
                var result = CreateDefaultPageForChapter(CurrentChapter);
                if (result == true) CurrentChapter = _chapterService.GetSectionByName(CourseCatalog.ASYNC_BINDING);
            }
            _topicList = new ObservableCollection<TopicDao>(CurrentChapter.SectionTopics);
        }

    }
}
