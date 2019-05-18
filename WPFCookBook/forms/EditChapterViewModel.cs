using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfCookBook.DB.Dao;
using WPFCookBook.Common;
using WPFCookBook.DataService.Contracts;
using WPFCookBook.Dto;

namespace WPFCookBook.forms
{
    public class EditChapterViewModel : BindableBase
    {
        private ICourseSectionService _sectionService;
        private ChapterDao _selectedChapter;
        private ChapterDto _modulesChapter;

        public EditChapterViewModel(ICourseSectionService sectService)
        {
            _sectionService = sectService;
            UpdateChapterCommand = new RelayCommandAsync<object>(SaveChanges, canSaveChanges);
        }

        public ChapterDao CurrentChapter
        {
            get { return _selectedChapter;  }
            set { SetProperty(ref _selectedChapter, value);  }
        }

        public event Action MasterRefresh = delegate { };

        public event Action NaivigateBackHome = delegate { };
        public RelayCommandAsync<object> UpdateChapterCommand { get; private set; }

        public void SetSelectedChapter(ChapterDao sect)
        {
            if(sect != null)
                _selectedChapter = sect;
        }

        private async Task SaveChanges(object param)
        {
            var updatedChapter = (ChapterDao)param;
            bool result = await _sectionService.UpdateSection(updatedChapter);

            if (result==true)
            {
                MessageBox.Show($"Successfully updated...: {updatedChapter.Title}");
            }
            MasterRefresh();
            NaivigateBackHome();
        }

        private bool canSaveChanges(object param)
        {
            return true;
        }
    }
}
