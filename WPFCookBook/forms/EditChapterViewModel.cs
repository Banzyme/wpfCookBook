using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFCookBook.Common;
using WPFCookBook.Contracts;
using WPFCookBook.Entities;

namespace WPFCookBook.forms
{
    public class EditChapterViewModel : BindableBase
    {
        private ICourseSectionService _sectionService;
        private WpfCourseSection _selectedChapter;

        public EditChapterViewModel(ICourseSectionService sectService)
        {
            _sectionService = sectService;
            UpdateChapterCommand = new RelayCommandAsync<object>(SaveChanges, canSaveChanges);
        }

        public WpfCourseSection CurrentChapter
        {
            get { return _selectedChapter;  }
            set { SetProperty(ref _selectedChapter, value);  }
        }

        public event Action NaivigateBackHome = delegate { };
        public RelayCommandAsync<object> UpdateChapterCommand { get; private set; }

        public void SetSelectedChapter(WpfCourseSection sect)
        {
            if(sect != null)
                _selectedChapter = sect;
        }

        private async Task SaveChanges(object param)
        {
            var updatedChapter = (WpfCourseSection)param;
            bool result = await _sectionService.UpdateSection(updatedChapter);

            if (result==true)
            {
                MessageBox.Show($"Successfully updated...: {updatedChapter.Title}");
            }
            NaivigateBackHome();
        }

        private bool canSaveChanges(object param)
        {
            return true;
        }
    }
}
