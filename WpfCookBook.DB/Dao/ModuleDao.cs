using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// The hierachical form of entities is: ModuleDao > ChapterDao > TopicDao >>>>>> Content or content document
/// </summary>
namespace WpfCookBook.DB.Dao
{
    public class ModuleDao : INotifyPropertyChanged
    {

        private string _name;
        private ICollection<ChapterDao> _moduleSections;

        [Key]
        public long ID { get; set; }
        public Guid ModuleID { get; set; }
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaisePropertyChangedEvent("Name");
            }
        }
        public ICollection<ChapterDao> ModuleSections
        {
            get { return _moduleSections; }
            set
            {
                _moduleSections = value;
                RaisePropertyChangedEvent("ModuleSections");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        protected virtual void RaisePropertyChangedEvent(string propertyName)
        {
            if(!string.IsNullOrEmpty(propertyName))
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public override string ToString()
        {
            string module = $"Chapter: [ {ID}, \n {Name}, \n With topics: { string.Join(" / \n", ModuleSections) }. \n";
            return module;
        }
    }
}
