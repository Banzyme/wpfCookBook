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
            var sectionTopics = _context.CourseSectionItems.ToList();
            var sections = _context.CourseSections.ToList();
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

        public ObservableCollection<WpfCourseModule> ModulesList { get; set; } = new ObservableCollection<WpfCourseModule>();

        private void OnNav(string treeItem)
        {

            try
            {
                switch ( treeItem.Replace(' ', '_').ToLower() )
                {
                    case "quick_intro":
                        CurrentViewModel = basicsModule;
                        break;

                    case "introduction_to_wpf_controls":
                        CurrentViewModel = controlsModule;
                        break;

                    default:
                        CurrentViewModel = controlsModule;
                        break;
                }

                //MessageBox.Show("Nav command: " + treeItem);
            }
            catch (Exception)
            {
                // Skip
                
            }
        }
    }
}
