using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFCookBook.Common;
using WPFCookBook.Contracts;
using WPFCookBook.Entities;

namespace WPFCookBook.forms
{
    public class CourseChapterFormViewModel : BindableBase
    {
        private ICourseSectionService _chaptersRepo;
        private ICourseModuleService _modService;
        private ObservableCollection<WpfCourseSection> _chaptersList;

        public CourseChapterFormViewModel(ICourseSectionService chaptersRepo, ICourseModuleService mods)
        {
            _chaptersRepo = chaptersRepo;
            _modService = mods;
            LoadInitialData();

            OnSaveChapterCommand = new CommandTemplate<object>(OnSaveChapter);
        }

        public string NewChapterTitle { get; set; }
        public ObservableCollection<WpfCourseSection> ChaptersList
        {
            get { return _chaptersList; }
            set
            {
                SetProperty(ref _chaptersList, value, "ChapterList");
            }
        }
        public ObservableCollection<WpfCourseModule> ModulesList { get; set; }
        public CommandTemplate<object> OnSaveChapterCommand { get; private set; }

        private void LoadInitialData()
        {
            var result = _chaptersRepo.GetAllSections();
            var modules = _modService.GetAllModules().ToList();
            _chaptersList = new ObservableCollection<WpfCourseSection>(result);
            ModulesList = new ObservableCollection<WpfCourseModule>(modules);
            NewChapterTitle = "";
        }

        private void Refresh()
        {
            //_chaptersList = new ObservableCollection<WpfCourseSection>(_chaptersRepo.GetAllSections());
        }

        private void OnSaveChapter(object module)
        {
            var selectedModule = (WpfCourseModule)module;

            bool result = _chaptersRepo.AddSectionWithRawSql(selectedModule.ID, NewChapterTitle);

            if (result == true)
            {
                Refresh();
                MessageBox.Show($"Successfully added {NewChapterTitle}, to module: {selectedModule.Name}");
            }


            // TODO: Error dialog
        }
    }
}
