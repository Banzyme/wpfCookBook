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
    public class WpfCourseModule
    {
        
        [Key]
        public long ID { get; set; }
        public Guid ModuleID { get; set; }
        public string Name { get; set; }
        public ICollection<WpfCourseSection> ModuleSections { get; set; }
   
    }
}
