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
using WPFCookBook.Common;
using WPFCookBook.Contracts;
using WPFCookBook.DataService;
using WPFCookBook.Entities;

namespace WPFCookBook.ViewModels.basics
{
    public class XamlFundamentalsViewModel : BindableBase
    {
        private ICourseSectionService _sectionService;
        private ICourseSectionItemService _sectItemsService;
        private WpfCourseSection section;
        private WpfCourseSectionItem currentTopic;

        #region constructor
        
        public XamlFundamentalsViewModel(ICourseSectionService sectionService, ICourseSectionItemService topics)
        {
            _sectionService = sectionService;
            _sectItemsService = topics;
            OnSaveChangesCommand = new CommandTemplate<FsRichTextBox>(OnSaveChanges);
            LoadInitialData();
        }

        #endregion

        #region Properties
        public CommandTemplate<FsRichTextBox> OnSaveChangesCommand { get; private set; }
        public ObservableCollection<WpfCourseSectionItem> TopicsList
        {
            get
            {
                ObservableCollection<WpfCourseSectionItem> result = new ObservableCollection<WpfCourseSectionItem>(section.SectionTopics.ToList());
                return result;
            }
        }
        #endregion

        #region Private methods
        private void LoadInitialData()
        {
            section = _sectionService.GetSectionByName("XAML Fundamentals");
        }

        private void OnSaveChanges(FsRichTextBox EditBox)
        {
            EditBox.UpdateDocumentBindings();

            currentTopic = (WpfCourseSectionItem)EditBox.DataContext;
            PersistTwoWayPropToDB(this.currentTopic.ID, this.currentTopic);
        }


        private void PersistTwoWayPropToDB(long ID, WpfCourseSectionItem topic)
        {
            // Todo: Add loader / progress bar
            var result = _sectItemsService.UpdateSectionItem(ID, topic);
            if (result)
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
