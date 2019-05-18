using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfCookBook.DB.Dao;
using WPFCookBook.Common;
using WPFCookBook.DataService.Contracts;


namespace WPFCookBook.forms
{
    public class EditModuleViewModel: BindableBase
    {
        private ICourseModuleService _moduleService;
        private ModuleDao _selectedModule;

        public EditModuleViewModel(ICourseModuleService moduleServie)
        {
            _moduleService = moduleServie;
            UpdateModuleCommand = new RelayCommandAsync<object>(OnUpdateModule, CanUpdateModule);

        }

        public event Action MasterRefresh = delegate { };
        public event Action<ModuleDao> MasterRefreshByID = delegate { };
        public event Action NaivigateBackHome = delegate { };
        public RelayCommandAsync<object> UpdateModuleCommand { get; private set; }
        public RelayCommand CancelCommand { get; private set; }
        public ModuleDao SelectedModule
        {
            get { return _selectedModule;  }
            set { SetProperty(ref _selectedModule, value); }
        }

        public void SetSelectedModule(ModuleDao module)
        {
            _selectedModule = module;
        }

        private async Task OnUpdateModule(object param)
        {
            ModuleDao updated = (ModuleDao)param;
            bool result = await _moduleService.UpdateModule(updated);
            if (result == true)
            {
                MasterRefreshByID(updated);
                MessageBox.Show($"Successfullly updated module: {updated.Name}");
                NaivigateBackHome();
            }
        }

        private bool CanUpdateModule(object param)
        {
            return true;
        }
    }
}
