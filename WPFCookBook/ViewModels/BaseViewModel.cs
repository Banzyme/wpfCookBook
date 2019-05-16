using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using WPFCookBook.forms;
using WPFCookBook.ViewModels.basics;

namespace WPFCookBook.ViewModels
{

    public class BaseViewModel : BindableBase
    {
        #region Private fields
        private BindableBase _CurrentViewModel;
        public ObservableCollection<WpfCourseModule> _modulesList;
        private ICourseModuleService _modService;

        private IndexViewModel IndexPage;
        private IntroToXamlViewModel basicsIntro;
        private XamlFundamentalsViewModel basicsFund;
        private BasicsViewModel basicsModule;
        private CourseChapterFormViewModel chapterForm;
        private EditChapterViewModel editChapter;
        private CourseModuleListViewModel moduleForm;
        private EditModuleViewModel editModule;
        #endregion

        #region Constructor
        public BaseViewModel()
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<IWpfCourseModulesRepository, WpfCourseModulesRepository>();
            container.RegisterType<IWpfCourseSectionRepository, WpfCourseSectionRepository>();
            container.RegisterType<IWpfCourseSectionItemRepo, WpfCourseSectionItemRepo>();

            container.RegisterType<ICourseModuleService, CourseModulesService>();
            container.RegisterType<ICourseSectionService, CourseSectionService>();
            container.RegisterType<ICourseSectionItemService, CourseSectionItemsService>();

            
            
            IndexPage = container.Resolve<IndexViewModel>();
            basicsIntro = container.Resolve<IntroToXamlViewModel>();
            basicsFund = container.Resolve<XamlFundamentalsViewModel>();
            basicsModule = container.Resolve<BasicsViewModel>();
            chapterForm = container.Resolve<CourseChapterFormViewModel>();
            editChapter = container.Resolve<EditChapterViewModel>();
            moduleForm = container.Resolve<CourseModuleListViewModel>();
            editModule = container.Resolve<EditModuleViewModel>();

            _modService = container.Resolve<CourseModulesService>();


            // Initial data load
            LoadViewData();
            

            //Setup default window content
            CurrentViewModel = IndexPage;

            // Child events - handlers
            chapterForm.EditChapterRequested += SwitchToEditChapterPage;
            moduleForm.EditModuleRequested += SwitchToEditModulePage;
            moduleForm.MasterRefresh += RefreshMainWindowCollections;
            editModule.NaivigateBackHome += GotoIndexPage;
            editModule.MasterRefresh += RefreshMainWindowCollections;

            editChapter.NaivigateBackHome += GotoIndexPage;
            editChapter.MasterRefresh += RefreshMainWindowCollections;

            // Commdands init
            NavigationCommand = new CommandTemplate<string>(OnNav);

        }
        #endregion

        private void LoadViewData()
        {
            var modResults = _modService.GetAllModules().ToList();
            _modulesList = new ObservableCollection<WpfCourseModule>(modResults);
        }

        #region Properties
        public BindableBase CurrentViewModel
        {
            get { return _CurrentViewModel; }
            set { SetProperty(ref _CurrentViewModel, value); }
        }

        public CommandTemplate<string> NavigationCommand { get; private set; }

        public ObservableCollection<WpfCourseModule> ModulesList
        {
            get { return _modulesList;  }
            set { SetProperty(ref _modulesList, value, "ModulesList");  }
        }
        #endregion



        #region Private methods
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

                    case "add_chapter_form":
                        CurrentViewModel = chapterForm;
                        break;

                    case "add_modules_form":
                        CurrentViewModel = moduleForm;
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

        public void RefreshMainWindowCollections()
        {
            _modulesList = new ObservableCollection<WpfCourseModule>(_modService.GetAllModules().ToList() );
            OnPropertyChanged("ModulesList");
        }

        public void GotoIndexPage()
        {
            CurrentViewModel = IndexPage;
        }

        public void SwitchToEditChapterPage(WpfCourseSection section)
        {
            editChapter.SetSelectedChapter(section);
            CurrentViewModel = editChapter;
        }

        private void SwitchToEditModulePage(WpfCourseModule mod)
        {
            editModule.SetSelectedModule(mod);
            CurrentViewModel = editModule;
        }
        #endregion

    }
}
