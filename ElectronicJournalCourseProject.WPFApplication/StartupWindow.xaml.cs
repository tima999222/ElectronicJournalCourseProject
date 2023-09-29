using ElectronicJournalCourseProject.Data.DataContext;
using System.Windows;

namespace ElectronicJournalCourseProject.WPFApplication
{
    /// <summary>
    /// Логика взаимодействия для StartupWindow.xaml
    /// </summary>
    public partial class StartupWindow : Window
    {
        private ElectronicJournalContextDesignTimeFactory _factory;
        private string[] _options = { "TIMA\\SQLEXPRESS", "ElectronicJournalDb" };

        public StartupWindow()
        {
            _factory = new ElectronicJournalContextDesignTimeFactory();
            var context = _factory.CreateDbContext(_options);
            context.Database.EnsureCreated();
            InitializeComponent();
        }
    }
}
