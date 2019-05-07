using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WPFCookBook.Common;
using WPFCookBook.DataService;
using WPFCookBook.Entities;

namespace WPFCookBook.ViewModels
{

    public class BaseViewModel : BindableBase
    {
        private readonly ApplicationDBContext _context = new ApplicationDBContext();
        private BindableBase _CurrentViewModel;
        private BasicsViewModel basicsModule = new BasicsViewModel();
        private ControlsSectionViewModel controlsModule = new ControlsSectionViewModel();

        public BaseViewModel()
        {
            NavigationCommand = new NavCommand<string>(OnNav);
            var modResults = _context.CourseModules.ToList();
            modResults.ForEach(item =>
           {
               
               ModulesList.Add(item);
           });
        }


        public BindableBase CurrentViewModel
        {
            get { return _CurrentViewModel; }
            set { SetProperty(ref _CurrentViewModel, value); }
        }

        public NavCommand<string> NavigationCommand { get; private set; }

        public ObservableCollection<WpfCourseModule> ModulesList { get; } = new ObservableCollection<WpfCourseModule>();

        private void OnNav(string treeItem)
        {

            try
            {

                MessageBox.Show("Nav command: " + treeItem);
            }
            catch (Exception)
            {
                // Skip
                
            }

            //switch (route)
            //{
            //    case "basics":
            //        CurrentViewModel = basicsModule;
            //        break;
            //    case "controls":
            //    default:
            //        CurrentViewModel = controlsModule;
            //        break;
            //}
        }
    }
}
