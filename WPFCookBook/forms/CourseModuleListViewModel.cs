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
    public class CourseModuleListViewModel : BindableBase
    {
        private ICourseModuleService _modulesService;
        private ObservableCollection<WpfCourseModule> _modulesList;
        private string newModule;

        public CourseModuleListViewModel(ICourseModuleService modService)
        {
            _modulesService = modService;
            LoadIntialData();
            InitialiseCommands();
            newModule = "";
        }

        public event Action<WpfCourseModule> EditModuleRequested = delegate { };
        public RelayCommand AddModuleCommand { get; private set; }
        public RelayCommand UpdateModuleCommand { get; private set; }
        public ObservableCollection<WpfCourseModule> ModulesList
        {
            get { return _modulesList; }
            set { SetProperty(ref _modulesList, value); }
        }
        public string NewModuleName
        {
            get { return newModule; }
            set { SetProperty(ref newModule, value); }
        }

        private void LoadIntialData()
        {
            var result = _modulesService.GetAllModules();
            _modulesList = new ObservableCollection<WpfCourseModule>(result);
        }

        private void InitialiseCommands()
        {
            AddModuleCommand = new RelayCommand(OnModuleAdd, CanAddModule);
            UpdateModuleCommand = new RelayCommand(OnUpdate, o => true);
        }

        private void OnModuleAdd(object param)
        {
            var newModule = new WpfCourseModule();
            MessageBox.Show($"Adding new module: {NewModuleName}");
        }

        private bool CanAddModule(object param)
        {
            return true;
        }

        private void OnUpdate(object param)
        {
            var selectedModule = (WpfCourseModule)param;
            EditModuleRequested(selectedModule);
        }


    }
}
