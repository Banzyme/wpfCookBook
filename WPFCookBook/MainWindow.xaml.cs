using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
using Unity;
using WPFCookBook.Contracts;
using WPFCookBook.DataService;
using WPFCookBook.DataService.Repository;
using WPFCookBook.Entities;
using WPFCookBook.ViewModels;

namespace WPFCookBook
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public BaseViewModel ViewModel
        {
            set { DataContext = value; }
        }

        private readonly ApplicationDBContext _context = new ApplicationDBContext();
        private ObservableCollection<WpfCourseModule> _modulesList = new ObservableCollection<WpfCourseModule>();
        public MainWindow()
        {
            InitializeComponent();

           

            List<WpfCourseModule> courses = new List<WpfCourseModule>();
            List<WpfCourseSectionItem> sectionTopics = new List<WpfCourseSectionItem>();
            List<WpfCourseSection> sections = new List<WpfCourseSection>();
            sectionTopics = _context.CourseSectionItems.ToList();
            sections = _context.CourseSections.ToList();
            courses = _context.CourseModules.ToList();

            //WPFCookMainNav.ItemsSource = courses;

            ////testDG.ItemsSource = courses;
        }
        public ObservableCollection<WpfCourseModule> ModulesList
        {
            get { return _modulesList; }
        }


        private void SelectionChanged(object sender, RoutedPropertyChangedEventArgs<Object> e)
        {
            //Perform actions when SelectedItem changes
            try
            {
                
                MessageBox.Show(((WpfCourseSection)e.NewValue).Title.ToString());
            }
            catch (Exception) { 
                // Skip
            }
            
        }
    }
}
