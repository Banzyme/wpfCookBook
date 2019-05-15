using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFCookBook.Common;
using WPFCookBook.Entities;

namespace WPFCookBook.forms
{
    public class EditChapterViewModel : BindableBase
    {
        private WpfCourseSection _selectedChapter;
        public EditChapterViewModel()
        {
            UpdateChapterCommand = new RelayCommand(SaveChanges, canSaveChanges);
        }

        public WpfCourseSection CurrentChapter
        {
            get { return _selectedChapter;  }
            set { SetProperty(ref _selectedChapter, value);  }
        }

        public RelayCommand UpdateChapterCommand { get; private set; }

        public void SetSelectedChapter(WpfCourseSection sect)
        {
            if(sect != null)
                _selectedChapter = sect;
        }

        private void SaveChanges(object param)
        {
            MessageBox.Show("Updateing..." + param);
        }

        private bool canSaveChanges(object param)
        {
            return true;
        }
    }
}
