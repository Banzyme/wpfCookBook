using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCookBook.Common;
using WPFCookBook.Contracts;
using WPFCookBook.Entities;

namespace WPFCookBook.forms
{
    public class CourseChapterFormViewModel: BindableBase
    {
        private ICourseSectionService _chaptersRepo;

        public CourseChapterFormViewModel(ICourseSectionService chaptersRepo)
        {
            _chaptersRepo = chaptersRepo;
            LoadInitialData();
        }

        public ObservableCollection<WpfCourseSection> ChaptersList { get; private set; }

        private void LoadInitialData()
        {
            var result = _chaptersRepo.GetAllSections();
            ChaptersList = new ObservableCollection<WpfCourseSection>(result);
        }
    }
}
