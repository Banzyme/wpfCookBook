﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCookBook.Services.DataService.Contracts;
using WPFCookBook.Shared.Constants;

namespace WPFCookBook.CourseContent.Controls
{
    public class LayoutControlsViewModel:ContentViewModelBase
    {
        public LayoutControlsViewModel(ICourseSectionService sectionService, ICourseSectionItemService topics) : base(sectionService, topics)
        {
            LoadInitialChildData(CourseCatalog.LAYOUTS);
        }
    }
}