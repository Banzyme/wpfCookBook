using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WpfCookBook.DB.Dao
{
    public class ChapterDao : INotifyPropertyChanged
    {


        private string _title;
        private ModuleDao _parentModule;
        private ICollection<TopicDao> _sectionTopics;

        [Key]
        public long ID { get; set; }
        public Guid SectionID { get; set; }
        public ModuleDao ParentModule
        {
            get { return _parentModule; }
            set
            {
                _parentModule = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ParentModule"));
            }
        }
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
            string topics = SectionTopics != null ? string.Join(" / \n", SectionTopics) : "<Not provided>";
            string chapter = $"Chapter: [ {ID}, \n {Title}, \n With topics: { topics }";
            return chapter;
        }
    }
}
