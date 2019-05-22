
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
using WPFCookBook.Shared;
using WPFCookBook.CourseContent.Basics;
using WPFCookBook.Services.DataService;
using WPFCookBook.Services.DataService.Contracts;

using WPFCookBook.forms;
using WPFCookBook.CourseContent.DataBinding;
using WPFCookBook.CourseContent.Layouts;
using WPFCookBook.CourseContent.Controls;
using WPFCookBook.Shared.Constants;

namespace WPFCookBook.ViewModels
{

    public partial  class BaseViewModel : BindableBase
    {
        #region Private fields
        private BindableBase _CurrentViewModel;
        public ObservableCollection<ModuleDao> _modulesList;
        private ICourseModuleService _modService;
        private IDictionary<string, BindableBase> WPFCookBookRouteMaps = new Dictionary<string, BindableBase>();

        private IndexViewModel IndexPage;

        #region form views
        private CourseChapterFormViewModel chapterForm;
        private EditChapterViewModel editChapter;
        private CourseModuleListViewModel moduleForm;
        private EditModuleViewModel editModule;
        #endregion

        #region Course content viewModels
        private IntroToWPFViewModel _introToWPFViewModel;
        private FirstTutorialViewModel _firstTutorialViewModel;
        private XAMLBootCampViewModel _xamlBootViewModel;
        private CsharpConceptsViewModel _csharpConceptsViewModel;
        private BasicsSummaryViewModel _basicsSummaryViewModel;

        private DockPanelViewModel _dockPanelViewModel;
        private GridPanelViewModel _gridPanelViewModel;
        private IntroToWPFLayoutsViewModel _introToWPFLayoutsViewModel;
        private StackPanelViewModel _stackPanelViewModel;
        private WrapPanelViewModel _wrapPanelViewModel;

        private ButtonControlViewModel _buttonControlViewModel;
        private DataDisplayControlsViewModel _dataDisplayControlsViewModel;
        private DialogControlViewModel _dialogControlViewModel;
        private InputControlsViewModel _inputControlsViewModel;
        private IntroToWPFControlsViewModel _introToWPFControlsViewModel;
        private LayoutControlsViewModel _layoutControlsViewModel;
        private MediaControlsViewModel _mediaControlsViewModel;
        private MenusViewModel _menusViewModel;
        private NavigationControlsViewModel _navigationControlsViewModel;
        private NotificationControlsViewModel _notificationControlsViewModel;
        private SelectionControlsViewModel _selectionControlsViewModel;

        protected AsyncBindingViewModel _asyncBindingViewModel;
        protected IntroToDataBindingViewModel _introToDataBindingViewModel;
        #endregion

        #endregion

        #region Constructor
        public BaseViewModel()
        {
            IUnityContainer container = new UnityContainer();

            #region Resolve data respositories
            container.RegisterType<IModuleRepository, ModuleRepository>();
            container.RegisterType<IChapterRepository, ChapterRepository>();
            container.RegisterType<ITopicRepository, TopicRespository>();
            #endregion

            #region Resolve data services
            container.RegisterType<ICourseModuleService, CourseModulesService>();
            _modService = container.Resolve<CourseModulesService>();
            container.RegisterType<ICourseSectionService, CourseSectionService>();
            container.RegisterType<ICourseSectionItemService, CourseSectionItemsService>();
            #endregion

            #region Course content viewmodels
            _buttonControlViewModel = container.Resolve<ButtonControlViewModel>();
            _dataDisplayControlsViewModel = container.Resolve<DataDisplayControlsViewModel>();
            _dialogControlViewModel = container.Resolve<DialogControlViewModel>();
            _inputControlsViewModel = container.Resolve<InputControlsViewModel>();
            _introToWPFControlsViewModel = container.Resolve<IntroToWPFControlsViewModel>();
            _layoutControlsViewModel = container.Resolve<LayoutControlsViewModel>();
            _mediaControlsViewModel = container.Resolve<MediaControlsViewModel>();
            _menusViewModel = container.Resolve<MenusViewModel>();
            _navigationControlsViewModel = container.Resolve<NavigationControlsViewModel>();
            _notificationControlsViewModel = container.Resolve<NotificationControlsViewModel>();
            _selectionControlsViewModel = container.Resolve<SelectionControlsViewModel>();

            _introToWPFViewModel = container.Resolve<IntroToWPFViewModel>();
            _firstTutorialViewModel = container.Resolve<FirstTutorialViewModel>();
            _xamlBootViewModel = container.Resolve<XAMLBootCampViewModel>();
            _csharpConceptsViewModel = container.Resolve<CsharpConceptsViewModel>();
            _basicsSummaryViewModel = container.Resolve<BasicsSummaryViewModel>();

            _dockPanelViewModel = container.Resolve<DockPanelViewModel>();
            _gridPanelViewModel = container.Resolve<GridPanelViewModel>();
            _introToWPFLayoutsViewModel = container.Resolve<IntroToWPFLayoutsViewModel>();
            _stackPanelViewModel = container.Resolve<StackPanelViewModel>();
            _wrapPanelViewModel = container.Resolve<WrapPanelViewModel>();


            _introToDataBindingViewModel = container.Resolve<IntroToDataBindingViewModel>();
            _asyncBindingViewModel = container.Resolve<AsyncBindingViewModel>();
            #endregion

            #region Data input form view models
            chapterForm = container.Resolve<CourseChapterFormViewModel>();
            editChapter = container.Resolve<EditChapterViewModel>();
            moduleForm = container.Resolve<CourseModuleListViewModel>();
            editModule = container.Resolve<EditModuleViewModel>();
            #endregion


            // Initial data load and Load Route Maps
            LoadMasterViewData();
            InitialiseRoutes();


            //Setup default window content
            IndexPage = container.Resolve<IndexViewModel>();
            CurrentViewModel = IndexPage;

            #region Event handlers
            chapterForm.EditChapterRequested += SwitchToEditChapterPage;
            chapterForm.MasterRefresh += RefreshMainWindowCollections;
            moduleForm.EditModuleRequested += SwitchToEditModulePage;
            moduleForm.MasterRefresh += RefreshMainWindowCollections;
            editModule.NaivigateBackHome += GotoIndexPage;
            editModule.MasterRefresh += RefreshMainWindowCollections;
            editModule.MasterRefreshByID += RefreshMainWindowCollectionsByID;

            editChapter.NaivigateBackHome += GotoIndexPage;
            editChapter.MasterRefresh += RefreshMasterListDirectly;
            #endregion

            #region Commands
            NavigationCommand = new CommandTemplate<string>(OnNavigationCommand);
            #endregion

        }
        #endregion



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
        private void LoadMasterViewData()
        {
            // NB: Only make db call if not in desgin mode
            if (!DesignerProperties.GetIsInDesignMode(new DependencyObject()))
            {
                _modulesList = new ObservableCollection<ModuleDao>(_modService.GetAllModules().ToList());
            }
            else
            {  // dummy data for designers
            }
        }


        private void OnNavigationCommand(string treeItem)
        {

            try
            {
                var nextView = WPFCookBookRouteMaps[FormatRouteName(treeItem)];
                CurrentViewModel = nextView;
            }
            catch (Exception)
            {
                MessageBox.Show($"Route /{treeItem} is not defined.");
                CurrentViewModel = IndexPage;
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
