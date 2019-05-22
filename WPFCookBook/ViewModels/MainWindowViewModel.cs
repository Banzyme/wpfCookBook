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
            WPFCookBookRouteMaps.Add(FormatRouteName(CourseCatalog.INTRO_TO_DATA_BINDING), _introToDataBindingViewModel);
            WPFCookBookRouteMaps.Add(FormatRouteName(CourseCatalog.ASYNC_BINDING), _asyncBindingViewModel);
        }

        protected string FormatRouteName(string route)
        {
            return route.Replace(' ', '_').ToLower();
        }
    }
}
