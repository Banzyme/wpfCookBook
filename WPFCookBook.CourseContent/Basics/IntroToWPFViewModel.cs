using FsWpfControls.FsRichTextBox;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WpfCookBook.DB.Dao;
using WPFCookBook.Services.DataService.Contracts;
using WPFCookBook.Shared;
using WPFCookBook.Shared.Commands;
using WPFCookBook.Shared.Constants;

namespace WPFCookBook.CourseContent.Basics
{
    public class IntroToWPFViewModel : ContentViewModelBase
    {
        #region Fields
        #endregion

        public IntroToWPFViewModel(ICourseSectionService sectionService, ICourseSectionItemService topics) : base(sectionService, topics)
        {
            LoadInitialData();
        }



        #region Properties
        #endregion


        #region Private methods
        private void LoadInitialData()
        {
            // TODO: Hard coded strings ? REALLY??
            CurrentChapter = _chapterService.GetSectionByName("1.1. Introduction to WPF");
            if (CurrentChapter != null & CurrentChapter.SectionTopics.Count == 0)
            {
                // Add default page and return updated topic
                var result = CreateDefaultPageForChapter(CurrentChapter);
                if (result == true) CurrentChapter = _chapterService.GetSectionByName("1.1. Introduction to WPF");
            }
            _topicList = new ObservableCollection<TopicDao>(CurrentChapter.SectionTopics );
        }

        #endregion

    }
}
