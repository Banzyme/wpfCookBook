using FsWpfControls.FsRichTextBox;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using WpfCookBook.DB.Dao;
using WPFCookBook.Common;
using WPFCookBook.DataService.Contracts;

namespace WPFCookBook.ViewModels.basics
{
    public class XamlFundamentalsViewModel : BindableBase
    {
        private ICourseSectionService _sectionService;
        private ICourseSectionItemService _sectItemsService;
        private ChapterDao section;
        private TopicDao currentTopic;
        private TopicDao _newTopic;
        private ObservableCollection<TopicDao> _topicsList;
        private Grid NewTopicForm;

        #region constructor

        public XamlFundamentalsViewModel(ICourseSectionService sectionService, ICourseSectionItemService topics)
        {
            _sectionService = sectionService;
            _sectItemsService = topics;
            OnSaveChangesCommand = new RelayCommandAsync< FsRichTextBox>(OnSaveChanges);
            AddTabItemCommand = new RelayCommandAsync<object>(OnAddTabItem);
            SaveTopicCommand = new RelayCommand(ShowAddTopicForm);
            LoadInitialData();
        }

        #endregion

        #region Properties
        public RelayCommandAsync<FsRichTextBox> OnSaveChangesCommand { get; private set; }
        public RelayCommandAsync<object> AddTabItemCommand { get; private set; }
        public RelayCommand SaveTopicCommand { get; private set; }
        public ObservableCollection<TopicDao> TopicsList
        {
            get
            {
                return _topicsList;
            }
            set
            {
                SetProperty(ref _topicsList, value, "TopicsList");
            }
        }

        public TopicDao NewTopic
        {
            get { return _newTopic; }
            set { SetProperty(ref _newTopic, value, "NewTopic"); }
        }
        #endregion

        #region Private methods
        private void LoadInitialData()
        {
            _newTopic = new TopicDao();
            section = _sectionService.GetSectionByName("XAML Fundamentals");
            _topicsList = new ObservableCollection<TopicDao>(section.SectionTopics.ToList());
        }

        private async Task OnSaveChanges(FsRichTextBox EditBox)
        {
            EditBox.UpdateDocumentBindings();

            currentTopic = (TopicDao)EditBox.DataContext;
            await PersistTwoWayPropToDB(this.currentTopic.ID, this.currentTopic);
        }


        private async Task PersistTwoWayPropToDB(long ID, TopicDao topic)
        {
            // Todo: Add loader / progress bar
            var result = await _sectItemsService.UpdateSectionItem(ID, topic);
            if (result == true)
            {
                MessageBox.Show("Changes saved.");
            }
            else
            {
                MessageBox.Show("An unexpected error has occured!");
            }
        }

        private void RefreshTopics(TopicDao NewEntry)
        {
            _topicsList.Add(NewEntry);
            OnPropertyChanged("TopicsList");
        }

        private async Task OnAddTabItem(object param)
        {
            var entry = (TopicDao)param;
            TopicDao savedtopic = null;

            bool result = _sectItemsService.AddTopicToChapterSql(entry, section.ID);
            if (result)
            {
                savedtopic = await _sectItemsService.GetTopicByName(entry.Title);
                
                if(savedtopic != null)
                    MessageBox.Show($"Added new tab item...with tittle: {savedtopic.ID} - {savedtopic.Title}");
            }
           
            // Update tabitems and collapse form
            RefreshTopics(savedtopic);
            if(NewTopicForm != null)
                NewTopicForm.Visibility = Visibility.Collapsed;
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

                MessageBox.Show($"Error parsing args: {e.Message}");
            }

        }
        #endregion

    }
}
