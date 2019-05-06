using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCookBook.Entities
{
    public class WpfCourseSectionItem
    {
        public long ID { get; set; }
        public Guid SectionItemID { get; set; }
        public string Title { get; set; }

        public string Subtitle { get; set; }

        public string Content { get; set; }
    }
}
