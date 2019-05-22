using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCookBook.Shared;
using WPFCookBook.Shared.Constants;

namespace WPFCookBook.ViewModels
{
    public partial class BaseViewModel : BindableBase
    {
        private void InitialiseRoutes()
        {
            #region Data input forms
            WPFCookBookRouteMaps.Add(FormatRouteName(CourseCatalog.ADD_MODULE_FORM), moduleForm);
            WPFCookBookRouteMaps.Add(FormatRouteName(CourseCatalog.ADD_CHAPTER_FORM), chapterForm);
            #endregion

            #region Basics
            WPFCookBookRouteMaps.Add(FormatRouteName(CourseCatalog.INTRO_TO_WPF), _introToWPFViewModel);
            WPFCookBookRouteMaps.Add(FormatRouteName(CourseCatalog.XAML_BOOTCAMP), _xamlBootViewModel);
            WPFCookBookRouteMaps.Add(FormatRouteName(CourseCatalog.CSHARP_CONCEPTS), _csharpConceptsViewModel);
            WPFCookBookRouteMaps.Add(FormatRouteName(CourseCatalog.FIRST_TUTORIAL), _firstTutorialViewModel);
            WPFCookBookRouteMaps.Add(FormatRouteName(CourseCatalog.BASICS_SUMMARY), _basicsSummaryViewModel);
            #endregion

            #region Layout panels
            WPFCookBookRouteMaps.Add(FormatRouteName(CourseCatalog.LAYOUTS_OVERVIEW), _introToWPFLayoutsViewModel);
            WPFCookBookRouteMaps.Add(FormatRouteName(CourseCatalog.DOCK_PANEL), _dockPanelViewModel);
            WPFCookBookRouteMaps.Add(FormatRouteName(CourseCatalog.GRID_PANEL), _gridPanelViewModel);
            WPFCookBookRouteMaps.Add(FormatRouteName(CourseCatalog.STACK_PANEL), _stackPanelViewModel);
            WPFCookBookRouteMaps.Add(FormatRouteName(CourseCatalog.WRAP_PANEL), _wrapPanelViewModel);
            #endregion

            #region Data Binding
            WPFCookBookRouteMaps.Add(FormatRouteName(CourseCatalog.INTRO_TO_DATA_BINDING), _introToDataBindingViewModel);
            WPFCookBookRouteMaps.Add(FormatRouteName(CourseCatalog.ASYNC_BINDING), _asyncBindingViewModel);
            #endregion

            #region Controls
            WPFCookBookRouteMaps.Add(FormatRouteName(CourseCatalog.BUTTONS), _buttonControlViewModel);
            WPFCookBookRouteMaps.Add(FormatRouteName(CourseCatalog.DATA_DISPLAY), _dataDisplayControlsViewModel);
            WPFCookBookRouteMaps.Add(FormatRouteName(CourseCatalog.DIALOGS), _dialogControlViewModel);
            WPFCookBookRouteMaps.Add(FormatRouteName(CourseCatalog.INPUT_CONTROLS), _inputControlsViewModel);
            WPFCookBookRouteMaps.Add(FormatRouteName(CourseCatalog.INTRO_TO_CONTROLS), _introToWPFControlsViewModel);
            WPFCookBookRouteMaps.Add(FormatRouteName(CourseCatalog.LAYOUTS), _layoutControlsViewModel);
            WPFCookBookRouteMaps.Add(FormatRouteName(CourseCatalog.MEDIA_CONTROLS), _mediaControlsViewModel);
            WPFCookBookRouteMaps.Add(FormatRouteName(CourseCatalog.MENUS), _menusViewModel);
            WPFCookBookRouteMaps.Add(FormatRouteName(CourseCatalog.NAVIGATION), _navigationControlsViewModel);
            WPFCookBookRouteMaps.Add(FormatRouteName(CourseCatalog.NOTIFICATIONS), _notificationControlsViewModel);
            WPFCookBookRouteMaps.Add(FormatRouteName(CourseCatalog.SELECTION_CONTROLS), _selectionControlsViewModel);
            #endregion
        }

        protected string FormatRouteName(string route)
        {
            return route.Replace(' ', '_').ToLower();
        }
    }
}
