using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WpfCookBook.DB.Dao
{
    public class ChapterDao : INotifyPropertyChanged
    {
        

        private string _title;
        private ICollection<TopicDao> _sectionTopics;

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

        public ICollection<TopicDao> SectionTopics
        {
            get { return _sectionTopics; }
            set
            {
                _sectionTopics = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SectionTopics"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public override string ToString()
        {
            string chapter = $"Chapter: [ {ID}, \n {Title}, \n With topics: { string.Join(" / ", SectionTopics ) }";
            return chapter;
        }
    }
}
