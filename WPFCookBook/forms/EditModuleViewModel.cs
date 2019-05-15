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
        private ICourseModuleService _moduleServie;
        private WpfCourseModule _selectedModule;

        public EditModuleViewModel(ICourseModuleService moduleServie)
        {
            _moduleServie = moduleServie;
            UpdateModuleCommand = new RelayCommand(OnUpdateModule, CanUpdateModule);

        }

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
            MessageBox.Show($"Update module: {param}");
        }

        private bool CanUpdateModule(object param)
        {
            return true;
        }
    }
}
