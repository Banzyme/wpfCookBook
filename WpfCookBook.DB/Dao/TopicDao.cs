using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace WpfCookBook.DB.Dao
{
    public class TopicDao : INotifyPropertyChanged
    {

        private string _content;

        public long ID { get; set; }
        public Guid SectionItemID { get; set; }
        public string Title { get; set; }

        public string Subtitle { get; set; }

        public string Content
        {
            get { return _content; }
            set
            {
                _content = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Content"));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public override string ToString()
        {
            string topic = $"Chapter: [ {ID}, \n {Title}, \n {Subtitle}. \n Document: { Content }. \n";
            return topic;
        }
    }
}
