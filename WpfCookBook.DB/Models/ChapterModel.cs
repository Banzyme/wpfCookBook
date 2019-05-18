using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCookBook.DB.Models
{
    public class ChapterModel
    {
        public long ID { get; set; }
        public string Title  { get; set; }
        public string SectionID { get; set; }
        public string ParentModule_ID { get; set; }
    }
}
