using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFCookBook.Common;
using WPFCookBook.Contracts;
using WPFCookBook.Entities;

namespace WPFCookBook.forms
{
    public class EditModuleViewModel: BindableBase
    {
        private ICourseModuleService _moduleService;
        private WpfCourseModule _selectedModule;

        public EditModuleViewModel(ICourseModuleService moduleServie)
        {
            _moduleService = moduleServie;
            UpdateModuleCommand = new RelayCommand(OnUpdateModule, CanUpdateModule);

        }

        public event Action NaivigateBackHome = delegate { };
        public RelayCommand UpdateModuleCommand { get; private set; }
        public RelayCommand CancelCommand { get; private set; }
        public WpfCourseModule SelectedModule
        {
            get { return _selectedModule;  }
            set { SetProperty(ref _selectedModule, value); }
        }

        public void SetSelectedModule(WpfCourseModule module)
        {
            _selectedModule = module;
        }

        private void OnUpdateModule(object param)
        {
            WpfCourseModule updated = (WpfCourseModule)param;
            bool result = _moduleService.UpdateModule(updated.ID, updated);
            if (result == true)
            {
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
