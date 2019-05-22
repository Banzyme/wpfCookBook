using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WPFCookBook.Common
{
    public class SaveFlowDocCommand  : ICommand
    {
        //private XamlFundamentalsViewModel _viewModel;
        //public SaveFlowDocCommand(XamlFundamentalsViewModel viewModel)
        //{
        //    _viewModel = viewModel;
        //}

       
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            try
            {
                // Can save to db here??
                
            }
            catch (Exception e)
            {

                MessageBox.Show(e.ToString());
            }
        }
    }
}
