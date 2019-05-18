using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfCookBook.DB.Dao;

namespace WPFCookBook.Dto
{
    public class ChapterDto : INotifyPropertyChanged
    {
        private ChapterDao _chapter;
        private ModuleDao _module;

        public ChapterDao Chapter
        {
            get { return _chapter; }
            set
            {
                _chapter = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Chapter"));
            }
        }

        public ModuleDao Module
        {
            get { return _module; }
            set
            {
                _module = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Module"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}
