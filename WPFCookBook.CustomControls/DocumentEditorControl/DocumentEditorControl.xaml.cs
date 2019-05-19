using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using WpfCookBook.DB.Dao;

namespace WPFCookBook.CustomControls.DocumentEditorControl
{
    /// <summary>
    /// Interaction logic for DocumentEditorControl.xaml
    /// </summary>
    public partial class DocumentEditorControl : UserControl
    {
        private ObservableCollection<TopicDao> _topicsList;
        public DocumentEditorControl()
        {
            InitializeComponent();
        }

        public ObservableCollection<TopicDao> TopicsList
        {
            get { return (ObservableCollection<TopicDao>)GetValue(TopicsListProperty); }
            set { SetValue(TopicsListProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TopicsListProperty =
            DependencyProperty.Register("TopicsList", typeof(ObservableCollection<TopicDao>), typeof(DocumentEditorControl), new PropertyMetadata(null));


    }
}
