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

namespace WPFCookBook.forms
{
    public class CourseModuleListViewModel : BindableBase
    {
        private ICourseModuleService _modulesService;
        private ObservableCollection<ModuleDao> _modulesList;
        private string newModule;

        public CourseModuleListViewModel(ICourseModuleService modService)
        {
            _modulesService = modService;
            LoadIntialData();
            InitialiseCommands();
            newModule = "";
        }

        // Used to signal state changes due to chiled actions
        public event Action MasterRefresh = delegate { };
        public event Action<ModuleDao> EditModuleRequested = delegate { };

        public RelayCommandAsync<object> AddModuleCommand { get; private set; }
        public RelayCommand UpdateModuleCommand { get; private set; }
        public RelayCommandAsync<object> DeleteModuleCommand { get; private set; }
        public ObservableCollection<ModuleDao> ModulesList
        {
            get { return _modulesList; }
            set { SetProperty(ref _modulesList, value); }
        }
        public string NewModuleName
        {
            get { return newModule; }
            set { SetProperty(ref newModule, value, "NewModuleName"); }
        }

        private void LoadIntialData()
        {
            var result = _modulesService.GetAllModules();
            _modulesList = new ObservableCollection<ModuleDao>(result);
        }

        private void InitialiseCommands()
        {
            AddModuleCommand = new RelayCommandAsync<object>(OnModuleAdd, CanAddModule);
            UpdateModuleCommand = new RelayCommand(OnUpdate, o => true);
            DeleteModuleCommand = new RelayCommandAsync<object>(onDeleteModule, o=> true);
        }

        private async Task RefreshModList(string name)
        {
            var entry = await _modulesService.FindModuleByName(name);
            _modulesList.Add(entry);
            newModule = "";
        }

        private async Task OnModuleAdd(object param)
        {
            var newModule = new ModuleDao();
            newModule.Name = NewModuleName;

            var result = await _modulesService.AddModule(newModule);
            if (result == true)
            {
                MessageBox.Show($"Adding new module: {NewModuleName}");
                await RefreshModList(NewModuleName);
                MasterRefresh();
            }
        }

        private bool CanAddModule(object param)
        {
            return true;
        }

        private void OnUpdate(object param)
        {
            var selectedModule = (ModuleDao)param;
            EditModuleRequested(selectedModule);
        }

        private async Task onDeleteModule(object ID)
        {
            long ModuleID = (long)ID;
            var res = MessageBox.Show("Are you sure you want to delete?", "Confirm delete", MessageBoxButton.YesNo);

            if (res == MessageBoxResult.Yes)
            {
                bool result = await _modulesService.DeleteModule(ModuleID);
                if (result == true)
                {
                    WpfCookBookUtils.RemoveEntryFromCollection( _modulesList , (item) => item.ID == ModuleID);
                    MasterRefresh();
                }
            }

        }


    }
}
