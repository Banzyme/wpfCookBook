﻿using FsWpfControls.FsRichTextBox;
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
using WPFCookBook.Shared.Utilities;

namespace WPFCookBook.CourseContent
{
    public abstract class ContentViewModelBase : BindableBase
    {
        #region Fields
        protected ICourseSectionItemService _topicService;
        protected ICourseSectionService _chapterService;

        protected TopicDao currentTopic;
        protected ChapterDao CurrentChapter;
        protected Grid NewTopicForm;
        protected TopicDao _newtopic = new TopicDao();
        protected ObservableCollection<TopicDao> _topicList;
        #endregion


        #region Constructor
        public ContentViewModelBase(ICourseSectionService sectionService, ICourseSectionItemService topics)
        {
            _topicService = topics;
            _chapterService = sectionService;

            OnSaveChangesCommand = new RelayCommandAsync<FsRichTextBox>(OnSaveChanges);
            SaveNewTopicCommand = new RelayCommandAsync<object>(OnAddTabItem);
            ShowTopicFormCommand = new RelayCommand(ShowAddTopicForm);
            DeleteTopicCommand = new RelayCommandAsync<object>(OnDeleteTopic, o => true);
        }
        #endregion


        #region Properties
        public RelayCommandAsync<FsRichTextBox> OnSaveChangesCommand { get; protected set; }
        public RelayCommandAsync<object> SaveNewTopicCommand { get; protected set; }
        public RelayCommand ShowTopicFormCommand { get; protected set; }
        public RelayCommandAsync<object> DeleteTopicCommand { get; protected set; }
        

        public TopicDao NewTopic
        {
            get
            {
                return _newtopic;
            }
            set
            {
                SetProperty(ref _newtopic, value);
            }
        }
        public ObservableCollection<TopicDao> TopicsList
        {
            get
            {
                return _topicList;
            }
            set { SetProperty(ref _topicList, value); }
        }
        #endregion


        #region protected methods
        protected virtual void LoadInitialChildData(string currentSection)
        {
            // TODO: Hard coded strings ? REALLY??
            CurrentChapter = _chapterService.GetSectionByName(currentSection);
            if (CurrentChapter != null & CurrentChapter.SectionTopics.Count == 0)
            {
                // Add default page and return updated topic
                var result = CreateDefaultPageForChapter(CurrentChapter);
                if (result == true) CurrentChapter = _chapterService.GetSectionByName(currentSection);
            }
            _topicList = new ObservableCollection<TopicDao>(CurrentChapter.SectionTopics);
        }


        protected virtual bool CreateDefaultPageForChapter(ChapterDao parentChapter)
        {
            TopicDao defaultTopic = new TopicDao()
            {
                Title = "Introduction",
                Subtitle = "What you will learn in this section",
                Content = DefaultStrings.DEFAULT_TOPIC_CONTENT
            };
            bool res = _topicService.AddTopicToChapterSql(defaultTopic, parentChapter.ID);
            return res;
        }


        protected async Task<bool> PersistTwoWayPropToDB(long ID, TopicDao topic)
        {
            // Todo: Add loader / progress bar
            var result = await _topicService.UpdateSectionItem(ID, topic);
            if (result == true)
            {
                MessageBox.Show("Changes saved.");
                return true;
            }
            else
            {
                MessageBox.Show("An unexpected error has occured!");
                return false;
            }
        }

        protected async Task OnSaveChanges(FsRichTextBox EditBox)
        {
            EditBox.UpdateDocumentBindings();
            currentTopic = (TopicDao)EditBox.DataContext;

            var result = await PersistTwoWayPropToDB(this.currentTopic.ID, this.currentTopic);
            if (result == false)
                MessageBox.Show($"Failed to update page, please try again later.");
        }

        protected void ShowAddTopicForm(object arg)
        {
            try
            {
                var grid = (Grid)arg;
                grid.Visibility = Visibility.Visible;
                NewTopicForm = grid;
            }
            catch (Exception e)
            {
                MessageBox.Show($"New topic form cant be displayed. Error parsing args: {e.Message}");
            }

        }

        protected async Task OnAddTabItem(object param)
        {
            var entry = (TopicDao)param;
            if (entry == null) return;
            entry.Content = DefaultStrings.DEFAULT_TOPIC_CONTENT;
            bool result = _topicService.AddTopicToChapterSql(entry, CurrentChapter.ID);


            if (result)
            {
                var savedtopic = await _topicService.GetTopicByName(entry.Title);

                if (savedtopic != null)
                {
                    MessageBox.Show($"Added new tab item...with tittle: {savedtopic.ID} - {savedtopic.Title}");
                    RefreshTopics(savedtopic);
                }

            }

            // Update tabitems and collapse form

            if (NewTopicForm != null)
                NewTopicForm.Visibility = Visibility.Collapsed;
        }

        protected void RefreshTopics(TopicDao NewEntry)
        {
            _topicList.Add(NewEntry);
            OnPropertyChanged("TopicsList");
        }

        protected async Task OnDeleteTopic(object ID)
        {
            long topicId = (long)ID;
            var res = MessageBox.Show("Are you sure you want to delete this topic?", "Confirm delete", MessageBoxButton.YesNo);

            if (res == MessageBoxResult.Yes)
            {
                bool result = await _topicService.DeleteSectionItem(topicId);
                if (result == true)
                {
                    CollectionHelpers.RemoveEntryFromCollection(_topicList, (item) => item.ID == topicId);
                }
            }


        }
        #endregion
    }
}
