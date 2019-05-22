using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCookBook.Services.DataService.Contracts;

namespace WPFCookBook.CourseContent.Basics
{
    public class FirstTutorialViewModel:ContentViewModelBase
    {
        public FirstTutorialViewModel(ICourseSectionService sectionService, ICourseSectionItemService topics) : base(sectionService, topics)
        {

        }
    }
}
