using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WpfCookBook.DB.Dao;
using WPFCookBook.Common;
using WPFCookBook.DataService.Contracts;

namespace WPFCookBook.forms
{
    public class CourseChapterFormViewModel : BindableBase
    {
        private ICourseSectionService _chaptersRepo;
        private ICourseModuleService _modService;
        private ObservableCollection<ChapterDao> _chaptersList;


        public CourseChapterFormViewModel(ICourseSectionService chaptersRepo, ICourseModuleService mods)
        {
            _chaptersRepo = chaptersRepo;
            _modService = mods;
            LoadInitialData();

            OnSaveChapterCommand = new RelayCommand(OnSaveChapter, o => true );
            OnDeleteSectionCommand = new RelayCommandAsync<object>(onDeleteChapter);
            OnUpdateSectionCommand = new RelayCommand(onUpdateChapter, o => true);
        }

        public bool CanSave(object section)
        {
            if (section == null)
                return true;

            try
            {
                var updateBtn = (Button)section;
                if (updateBtn.Visibility == Visibility.Visible)
                {
                    return false;
                }
            }
            catch (Exception)
            {

               // skip
            }


            return true;
        }
        // Used to signal state changes due to chiled actions
        public event Action MasterRefresh = delegate { };
        public string NewChapterTitle { get; set; }
        public ObservableCollection<ChapterDao> ChaptersList
        {
            get { return _chaptersList; }
            set
            {
                SetProperty(ref _chaptersList, value, "ChapterList");
            }
        }
        public ObservableCollection<ModuleDao> ModulesList { get; set; }
        public RelayCommand OnSaveChapterCommand { get; private set; }
        public RelayCommandAsync<object> OnDeleteSectionCommand { get; private set; }
        public RelayCommand OnUpdateSectionCommand { get; private set; }
        public event Action<ChapterDao> EditChapterRequested = delegate { };

        private void LoadInitialData()
        {
            var result = _chaptersRepo.GetAllSections();
            var modules = _modService.GetAllModules().ToList();

            _chaptersList = new ObservableCollection<ChapterDao>(result);
            ModulesList = new ObservableCollection<ModuleDao>(modules);
            NewChapterTitle = "";
            
        }

        private void Refresh(string sectName)
        {
            var newEntry = _chaptersRepo.GetSectionByName(sectName);
            _chaptersList.Add(newEntry);
        }

        private void OnSaveChapter(object module)
        {
            var selectedModule = (ModuleDao)module;

            bool result = _chaptersRepo.AddSectionWithRawSql(selectedModule.ID, NewChapterTitle);

            if (result == true)
            {
                Refresh(NewChapterTitle);
                MasterRefresh();
                MessageBox.Show($"Successfully added {NewChapterTitle}, to module: {selectedModule.Name}");
            }
            // TODO: Error dialog
        }



        private void onUpdateChapter(object obj)
        {
            var selectedSection = (ChapterDao)obj;
            EditChapterRequested(selectedSection);
        }

        private async Task onDeleteChapter(object ID)
        {
            long sectionID = (long)ID;
            var res = MessageBox.Show("Are you sure you want to delete?", "Confirm delete", MessageBoxButton.YesNo);

            if (res == MessageBoxResult.Yes)
            {
                bool result = await _chaptersRepo.DeleteSection(sectionID);
                if (result == true)
                {
                    MasterRefresh();
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
