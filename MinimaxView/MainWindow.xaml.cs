using MinimaxViewModel;
using System.Windows;
using System.Windows.Controls;

namespace MinimaxView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainWindowVm _context;
        public MainWindow()
        {
            InitializeComponent();
            _context = new MainWindowVm((Application.Current as App)?.Context!);
            DataContext = _context;
        }

        private void CmbCity_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}