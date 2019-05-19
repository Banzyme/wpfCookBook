using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using Unity;
using WpfCookBook.DB.Dao;
using WpfCookBook.DB.Repository;
using WPFCookBook.Common;
using WPFCookBook.DataService;
using WPFCookBook.DataService.Contracts;
using WPFCookBook.forms;
using WPFCookBook.ViewModels.basics;
using WPFCookBook.ViewModels.layout;

namespace WPFCookBook.ViewModels
{

    public class BaseViewModel : BindableBase
    {
        #region Private fields
        private BindableBase _CurrentViewModel;
        public ObservableCollection<ModuleDao> _modulesList;
        private ICourseModuleService _modService;

        private IndexViewModel IndexPage;
        private IntroToXamlViewModel basicsIntro;
        private XamlFundamentalsViewModel basicsFund;
        private ErrorPageVieModel basicsModule;
        private GridLayoutChapterViewModel gridLayoutChapter;


        private CourseChapterFormViewModel chapterForm;
        private EditChapterViewModel editChapter;
        private CourseModuleListViewModel moduleForm;
        private EditModuleViewModel editModule;
        #endregion

        #region Constructor
        public BaseViewModel()
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<IModuleRepository, ModuleRepository>();
            container.RegisterType<IChapterRepository, ChapterRepository>();
            container.RegisterType<ITopicRepository, TopicRespository>();

            container.RegisterType<ICourseModuleService, CourseModulesService>();
            container.RegisterType<ICourseSectionService, CourseSectionService>();
            container.RegisterType<ICourseSectionItemService, CourseSectionItemsService>();

            
            
            IndexPage = container.Resolve<IndexViewModel>();
            basicsIntro = container.Resolve<IntroToXamlViewModel>();
            basicsFund = container.Resolve<XamlFundamentalsViewModel>();
            basicsModule = container.Resolve<ErrorPageVieModel>();
            gridLayoutChapter = container.Resolve<GridLayoutChapterViewModel>();

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
            chapterForm.MasterRefresh += RefreshMainWindowCollections;
            moduleForm.EditModuleRequested += SwitchToEditModulePage;
            moduleForm.MasterRefresh += RefreshMainWindowCollections;
            editModule.NaivigateBackHome += GotoIndexPage;
            editModule.MasterRefresh += RefreshMainWindowCollections;
            editModule.MasterRefreshByID += RefreshMainWindowCollectionsByID;

            editChapter.NaivigateBackHome += GotoIndexPage;
            editChapter.MasterRefresh += RefreshMasterListDirectly;

            // Commdands init
            NavigationCommand = new CommandTemplate<string>(OnNav);

        }
        #endregion

        private void LoadViewData()
        {
            if( DesignerProperties.GetIsInDesignMode(new DependencyObject()))
            {
                _modulesList = new ObservableCollection<ModuleDao>(_modService.GetAllModules().ToList());
            }           
        }

        #region Properties
        public BindableBase CurrentViewModel
        {
            get { return _CurrentViewModel; }
            set { SetProperty(ref _CurrentViewModel, value); }
        }

        public CommandTemplate<string> NavigationCommand { get; private set; }

        public ObservableCollection<ModuleDao> ModulesList
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

                    case "grid_panel":
                        CurrentViewModel = gridLayoutChapter;
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

        public async void RefreshMainWindowCollections()
        {
            _modulesList = new ObservableCollection<ModuleDao>( await _modService.GetAllModulesAsync() );
            OnPropertyChanged("ModulesList");
        }

        private void RefreshMainWindowCollectionsByID(ModuleDao updated)
        {
            var module = _modulesList.FirstOrDefault(x => x.ID == updated.ID);
            if (module!= null) module.Name = updated.Name;
            OnPropertyChanged("ModulesList");
        }

        private void RefreshMasterListDirectly(ObservableCollection<ModuleDao> updated)
        {
            _modulesList = updated;
            OnPropertyChanged("ModulesList");
        }

        public void GotoIndexPage()
        {
            CurrentViewModel = IndexPage;
        }

        public void SwitchToEditChapterPage(ChapterDao section)
        {
            editChapter.SetSelectedChapter(section);
            CurrentViewModel = editChapter;
        }

        private void SwitchToEditModulePage(ModuleDao mod)
        {
            editModule.SetSelectedModule(mod);
            CurrentViewModel = editModule;
        }
        #endregion

    }
}
