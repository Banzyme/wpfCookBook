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

namespace WPFCookBook.CourseContent.Basics
{
    public class IntroToWPFViewModel : BindableBase
    {
        private TopicDao currentTopic;
        private ChapterDao CurrentChapter;
        private Grid NewTopicForm;

        private ICourseSectionItemService _topicService;
        private ICourseSectionService _chapterService;
        private List<TopicDao> _dummyTopics = new List<TopicDao>()
        {
            new TopicDao()
        {
            ID = 1,
            Title = "No title"
        }
        };
        private ObservableCollection<TopicDao> _topicList;

        private TopicDao _newtopic = new TopicDao() { ID = 2, Title = "NEW TOPIC" };

        public IntroToWPFViewModel(ICourseSectionService sectionService, ICourseSectionItemService topics)
        {
            _topicService = topics;
            _chapterService = sectionService;

            // TODO: REALLY??
            CurrentChapter = _chapterService.GetSectionByName("1.1. Introduction to WPF");

            OnSaveChangesCommand = new RelayCommandAsync<FsRichTextBox>(OnSaveChanges);
            SaveNewTopicCommand = new RelayCommandAsync<object>(OnAddTabItem);
            ShowTopicFormCommand = new RelayCommand(ShowAddTopicForm);

            LoadInitialData();
        }


        #region Properties

        public RelayCommandAsync<FsRichTextBox> OnSaveChangesCommand { get; private set; }
        public RelayCommandAsync<object> SaveNewTopicCommand { get; private set; }
        public RelayCommand ShowTopicFormCommand { get; private set; }

        public TopicDao NewTopic
        {
            get
            { return _newtopic; }
            set { _newtopic = value; }
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



        #region Private methods
        private void LoadInitialData()
        {
            _topicList = new ObservableCollection<TopicDao>( _topicService.GetAllSectionItems() );
        }


        private async Task<bool> PersistTwoWayPropToDB(long ID, TopicDao topic)
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

        private async Task OnSaveChanges(FsRichTextBox EditBox)
        {
            EditBox.UpdateDocumentBindings();
            currentTopic = (TopicDao)EditBox.DataContext;
           
            var result = await PersistTwoWayPropToDB(this.currentTopic.ID, this.currentTopic);
            if(result == true)
                MessageBox.Show($"Updating changes:...{currentTopic}");
        }

        private void ShowAddTopicForm(object arg)
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

        private async Task OnAddTabItem(object param)
        {
            var entry = (TopicDao)param;
            TopicDao savedtopic = null;

            MessageBox.Show("Adding brand new topic!");

            bool result = _topicService.AddTopicToChapterSql(entry, CurrentChapter.ID);
            if (result)
            {
                savedtopic = await _topicService.GetTopicByName(entry.Title);

                if (savedtopic != null)
                    MessageBox.Show($"Added new tab item...with tittle: {savedtopic.ID} - {savedtopic.Title}");
            }

            // Update tabitems and collapse form
            RefreshTopics(savedtopic);
            if (NewTopicForm != null)
                NewTopicForm.Visibility = Visibility.Collapsed;
        }

        private void RefreshTopics(TopicDao NewEntry)
        {
            _topicList.Add(NewEntry);
            OnPropertyChanged("TopicsList");
        }
        #endregion

    }
}
