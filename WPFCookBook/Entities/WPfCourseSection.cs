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
    public class WpfCourseSection : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private string _title;
        private ICollection<WpfCourseSectionItem> _sectionTopics;

        [Key]
        public long ID { get; set; }
        public Guid SectionID { get; set; }
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Title"));
            }
        }

        public ICollection<WpfCourseSectionItem> SectionTopics
        {
            get { return _sectionTopics; }
            set
            {
                _sectionTopics = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SectionTopics"));
            }
        }
    }
}
