using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCookBook.Common;

namespace WPFCookBook.Entities
{
    public class WpfCourseSectionItem : INotifyPropertyChanged
    {
        public string Content { get; set; }

        public long ID { get; set; }
        public Guid SectionItemID { get; set; }
        public string Title { get; set; }

        public string Subtitle { get; set; }

        //public string Content
        //{
        //    get { return _content; }
        //    set
        //    {

        //        _content = value;
        //        NotifyPropertyChanged("Content");
        //    }
        //}

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(String propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
