﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfCookBook.DB.Dao;
using WPFCookBook.Services.DataService.Contracts;
using WPFCookBook.Shared.Constants;

namespace WPFCookBook.CourseContent.Layouts
{
    public class IntroToWPFLayoutsViewModel: ContentViewModelBase
    {
        public IntroToWPFLayoutsViewModel(ICourseSectionService sectionService, ICourseSectionItemService topics) : base(sectionService, topics)
        {
            LoadInitialData();
        }

        private void LoadInitialData()
        {
            // TODO: Hard coded strings ? REALLY??
            CurrentChapter = _chapterService.GetSectionByName( CourseCatalog.LAYOUTS_OVERVIEW );
            if (CurrentChapter != null & CurrentChapter.SectionTopics.Count == 0)
            {
                // Add default page and return updated topic
                var result = CreateDefaultPageForChapter(CurrentChapter);
                if (result == true) CurrentChapter = _chapterService.GetSectionByName(CourseCatalog.LAYOUTS_OVERVIEW);
            }
            _topicList = new ObservableCollection<TopicDao>(CurrentChapter.SectionTopics);
        }

    }
}
