using System.Windows;

namespace ElectronicJournalCourseProject.WPFApplication
{
    /// <summary>
    /// Логика взаимодействия для StartupWindow.xaml
    /// </summary>
    public partial class StartupWindow : Window
    {

        public StartupWindow() 
        { 
            EntryPoint.StartApp();
            InitializeComponent();
        }
    }
}
