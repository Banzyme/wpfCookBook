using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFCookBook.Views.basics
{
    /// <summary>
    /// Interaction logic for XamlFundamentals.xaml
    /// </summary>
    public partial class XamlFundamentals : UserControl
    {
        public XamlFundamentals()
        {
            InitializeComponent();
            var test = EditBox.Document;
        }

        private void OnForceUpdateClick(object sender, RoutedEventArgs e)
        {
            this.EditBox.UpdateDocumentBindings();
        }
    }
}
