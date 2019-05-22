using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCookBook.Services.DataService.Contracts;
using WPFCookBook.Shared.Constants;

namespace WPFCookBook.CourseContent.Layouts
{
    public class WrapPanelViewModel : ContentViewModelBase
    {

        public WrapPanelViewModel(ICourseSectionService sectionService, ICourseSectionItemService topics) : base(sectionService, topics)
        {
            LoadInitialChildData(CourseCatalog.STACK_PANEL);
        }
    }
}
