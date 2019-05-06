using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCookBook.Entities
{
    public class WpfCourseSection
    {
        [Key]
        public long ID { get; set; }
        public Guid SectionID { get; set; }
        public string Title { get; set; }

        public ICollection<WpfCourseSectionItem> SectionTopics { get; set; }
    }
}
