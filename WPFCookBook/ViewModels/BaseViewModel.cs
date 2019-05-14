using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Unity;
using WPFCookBook.Common;
using WPFCookBook.Contracts;
using WPFCookBook.DataService;
using WPFCookBook.DataService.Repository;
using WPFCookBook.Entities;
using WPFCookBook.ViewModels.basics;

namespace WPFCookBook.ViewModels
{

    public class BaseViewModel : BindableBase
    {
        private readonly ApplicationDBContext _context = new ApplicationDBContext();
        private BindableBase _CurrentViewModel;
        private IndexViewModel IndexPage = new IndexViewModel();
        private BasicsViewModel basicsModule = new BasicsViewModel();
        private ControlsSectionViewModel controlsModule = new ControlsSectionViewModel();

        private IntroToXamlViewModel basicsIntro = new IntroToXamlViewModel();

        private XamlFundamentalsViewModel basicsFund;

        public BaseViewModel()
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<IWpfCourseModulesRepository, WpfCourseModulesRepository>();
            container.RegisterType<IWpfCourseSectionRepository, WpfCourseSectionRepository>();
            container.RegisterType<IWpfCourseSectionItemRepo, WpfCourseSectionItemRepo>();
            container.RegisterType<ICourseSectionService, CourseSectionService>();
            container.RegisterType<ICourseSectionItemService, CourseSectionItemsService>();

            basicsFund = container.Resolve<XamlFundamentalsViewModel>();


            NavigationCommand = new CommandTemplate<string>(OnNav);
            var sectionTopics = _context.CourseSectionItems.ToList();
            var sections = _context.CourseSections.ToList();
            var modResults = _context.CourseModules.ToList();
            modResults.ForEach(item =>
           {
               ModulesList.Add(item);
           });

            //Setup default window content
            CurrentViewModel = IndexPage;
        }


        public BindableBase CurrentViewModel
        {
            get { return _CurrentViewModel; }
            set { SetProperty(ref _CurrentViewModel, value); }
        }

        public CommandTemplate<string> NavigationCommand { get; private set; }

        public ObservableCollection<WpfCourseModule> ModulesList { get; set; } = new ObservableCollection<WpfCourseModule>();

        private void OnNav(string treeItem)
        {

            try
            {
                switch (treeItem.Replace(' ', '_').ToLower())
                {
                    case "quick_intro":
                        CurrentViewModel = basicsIntro;
                        break;



                    case "xaml_fundamentals":
                        CurrentViewModel = basicsFund;


                        break;

                    case "introduction_to_wpf_controls":
                        CurrentViewModel = controlsModule;
                        break;

                    default:
                        CurrentViewModel = basicsModule;
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
