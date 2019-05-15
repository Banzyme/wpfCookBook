using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCookBook.Common;
using WPFCookBook.Entities;

namespace WPFCookBook.forms
{
    public class EditChapterViewModel : BindableBase
    {
        private WpfCourseSection _selectedChapter;
        public EditChapterViewModel()
        {
        }

        public WpfCourseSection CurrentChapter
        {
            get { return _selectedChapter;  }
            set { SetProperty(ref _selectedChapter, value);  }
        }

        public void SetSelectedChapter(WpfCourseSection sect)
        {
            if(sect != null)
                _selectedChapter = sect;
        }
    }
}
