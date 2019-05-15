using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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
            OnDeleteSectionCommand = new CommandTemplate<long>(onDeleteChapter);
            OnUpdateSectionCommand = new CommandTemplate<object>(onUpdateChapter);
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
        public CommandTemplate<long> OnDeleteSectionCommand { get; private set; }
        public CommandTemplate<object> OnUpdateSectionCommand { get; private set; }

        private void LoadInitialData()
        {
            var result = _chaptersRepo.GetAllSections();
            var modules = _modService.GetAllModules().ToList();
            _chaptersList = new ObservableCollection<WpfCourseSection>(result);
            ModulesList = new ObservableCollection<WpfCourseModule>(modules);
            NewChapterTitle = "";
        }

        private void Refresh(string sectName)
        {
            var newEntry = _chaptersRepo.GetSectionByName(sectName);
            _chaptersList.Add(newEntry);
        }

        private void OnSaveChapter(object module)
        {
            var selectedModule = (WpfCourseModule)module;

            bool result = _chaptersRepo.AddSectionWithRawSql(selectedModule.ID, NewChapterTitle);

            if (result == true)
            {
                Refresh(NewChapterTitle);
                MessageBox.Show($"Successfully added {NewChapterTitle}, to module: {selectedModule.Name}");
            }


            // TODO: Error dialog
        }

        private void onUpdateChapter(object sectionID)
        {
            var datagrid = (DataGrid)sectionID;

            MessageBox.Show($"{ datagrid.SelectedValue }");
            //bool result = _chaptersRepo.UpdateSection((long)sectionID, "");

            //if (result == true)
            //{
            //    Refresh(NewChapterTitle);
            //    MessageBox.Show($"Successfully updated chapter.");
            //}
        }

        private void onDeleteChapter(long sectionID)
        {
            var res = MessageBox.Show("Are you sure you want to delete?", "Confirm delete", MessageBoxButton.YesNo);

            if (res == MessageBoxResult.Yes)
            {
                bool result = _chaptersRepo.DeleteSection(sectionID);
                if (result)
                {
                    RemoveEntryFromCollection(_chaptersList, (item) => item.ID == sectionID);
                }
            }

        }


        private void RemoveEntryFromCollection<T>(ObservableCollection<T> collection, Func<T, bool> condition)
        {
            try
            {
                collection.Remove(collection.Where(condition).Single());
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
