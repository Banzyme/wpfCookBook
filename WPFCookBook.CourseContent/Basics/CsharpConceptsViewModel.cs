using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCookBook.Services.DataService.Contracts;

namespace WPFCookBook.CourseContent.Basics
{
    public class CsharpConceptsViewModel:ContentViewModelBase
    {
        public CsharpConceptsViewModel(ICourseSectionService sectionService, ICourseSectionItemService topics) : base(sectionService, topics)
        {
                
        }
    }
}
