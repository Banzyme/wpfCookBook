using FsWpfControls.FsRichTextBox;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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

        #region constructor
        
        public XamlFundamentalsViewModel(ICourseSectionService sectionService, ICourseSectionItemService topics)
        {
            _sectionService = sectionService;
            _sectItemsService = topics;
            OnSaveChangesCommand = new RelayCommandAsync< FsRichTextBox>(OnSaveChanges);
            LoadInitialData();
        }

        #endregion

        #region Properties
        public RelayCommandAsync<FsRichTextBox> OnSaveChangesCommand { get; private set; }
        public ObservableCollection<TopicDao> TopicsList
        {
            get
            {
                ObservableCollection<TopicDao> result = new ObservableCollection<TopicDao>(section.SectionTopics.ToList());
                return result;
            }
        }
        #endregion

        #region Private methods
        private void LoadInitialData()
        {
            section = _sectionService.GetSectionByName("XAML Fundamentals");
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

        #endregion

    }
}
