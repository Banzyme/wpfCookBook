using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfCookBook.DB.Dao;
using WPFCookBook.Common;
using WPFCookBook.DataService.Contracts;
using WPFCookBook.Dto;

namespace WPFCookBook.forms
{
    public class EditChapterViewModel : BindableBase
    {
        private ICourseSectionService _sectionService;
        private ICourseModuleService _modService;
        private ChapterDao _selectedChapter;
        private int _selectedModuleIndex;
        private ObservableCollection<ModuleDao> _modulesList;
       

        public EditChapterViewModel(ICourseSectionService sectService, ICourseModuleService moduleService)
        {
            _sectionService = sectService;
            _modService = moduleService;
            UpdateChapterCommand = new RelayCommandAsync<object>(SaveChanges, canSaveChanges);
        }

        public void LoadInitialData()
        {
            var modulesResult = _modService.GetAllModules(); 
            _modulesList = new ObservableCollection<ModuleDao>(modulesResult);

            var _selectedMod = _modulesList.Where(mod => mod.ID == _selectedChapter?.ParentModule.ID).SingleOrDefault();
            _selectedModuleIndex = _modulesList.IndexOf(_selectedMod);
        }

        public ChapterDao CurrentChapter
        {
            get { return _selectedChapter;  }
            set { SetProperty(ref _selectedChapter, value);  }
        }

        public int SelectedModuleIndex
        {
            get { return _selectedModuleIndex; }
            set { SetProperty(ref _selectedModuleIndex, value); }
        }

        public ObservableCollection<ModuleDao> ModulesList
        {
            get { return _modulesList; }
            set { SetProperty(ref _modulesList, value); }
        }

        public event Action MasterRefresh = delegate { };

        public event Action NaivigateBackHome = delegate { };
        public RelayCommandAsync<object> UpdateChapterCommand { get; private set; }

        public void SetSelectedChapter(ChapterDao sect)
        {
            if(sect != null)
                _selectedChapter = sect;

            LoadInitialData();
        }

        private async Task SaveChanges(object param)
        {
            var updatedChapter = (ChapterDao)param;
            bool result = await _sectionService.UpdateSection(updatedChapter);

            if (result==true)
            {
                MessageBox.Show($"Successfully updated...: {updatedChapter.Title}");
                MasterRefresh();
            }
            NaivigateBackHome();
        }

        private bool canSaveChanges(object param)
        {
            return true;
        }
    }
}
