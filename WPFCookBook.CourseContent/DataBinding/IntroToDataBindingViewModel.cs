using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfCookBook.DB.Dao;
using WPFCookBook.Services.DataService.Contracts;
using WPFCookBook.Shared.Constants;

namespace WPFCookBook.CourseContent.DataBinding
{
    public class IntroToDataBindingViewModel : ContentViewModelBase
    {

        public IntroToDataBindingViewModel(ICourseSectionService sectionService, ICourseSectionItemService topics) : base(sectionService, topics)
        {
            LoadInitialChildData(CourseCatalog.INTRO_TO_DATA_BINDING);
        }

    }
}
