using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCookBook.Common;

namespace WPFCookBook.Entities
{
    public class WpfCourseModule : BindableBase
    {
        private string _name;
        private ICollection<WpfCourseSection> _moduleSections;

        [Key]
        public long ID { get; set; }
        public Guid ModuleID { get; set; }
        public string Name
        {
            get { return _name; }
            set
            {
                SetProperty(ref _name, value, "Name");
            }
        }
        public ICollection<WpfCourseSection> ModuleSections
        {
            get { return _moduleSections; }
            set { SetProperty(ref _moduleSections, value, "ModuleSections"); }
        }

    }
}
