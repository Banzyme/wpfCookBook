using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCookBook.Entities
{
    public class WpfCourseSection
    {
        public Guid ID { get; set; }
        public string Title { get; set; }

        public IEnumerable<WpfCourseSectionItem> SectionTopics { get; set; }
    }
}
