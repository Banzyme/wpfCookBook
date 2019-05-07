using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCookBook.Common;

namespace WPFCookBook.ViewModels
{

    public class BaseViewModel : BindableBase
    {
        private BindableBase _CurrentViewModel;
        private BasicsViewModel basicsModule = new BasicsViewModel();
        private ControlsSectionViewModel controlsModule = new ControlsSectionViewModel();
        public BaseViewModel()
        {
            NavigationCommand = new NavCommand<string>(OnNav);
        }

      

        public BindableBase CurrentViewModel
        {
            get { return _CurrentViewModel; }
            set { SetProperty(ref _CurrentViewModel, value); }
        }

        public NavCommand<string> NavigationCommand { get; private set; }

        private void OnNav(string destination)
        {

            switch (destination)
            {
                case "basics":
                    CurrentViewModel = basicsModule;
                    break;
                case "controls":
                default:
                    CurrentViewModel = controlsModule;
                    break;
            }
        }
    }
}
