using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCookBook.Common;

namespace WPFCookBook.ViewModels
{
    public class ErrorPageVieModel : BindableBase
    {
        private string _errorMsg;
        public ErrorPageVieModel(string message = "Error: View not configured")
        {
            _errorMsg = message;
        }

        public string ErrorMessage
        {
            get { return _errorMsg; }
            set { SetProperty(ref _errorMsg, value); }
        }
    }
}
