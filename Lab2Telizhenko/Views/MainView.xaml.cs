using Lab2Telizhenko.Models;
using Lab2Telizhenko.ViewModels;
using System.Windows.Controls;
namespace Lab2Telizhenko.Views
{
    /// <summary>
    /// Логика взаимодействия для MainView.xaml
    /// </summary>
    public partial class MainView : UserControl
    {
        public MainView(Storage storage)
        {
            InitializeComponent();
            var viewModel = new MainViewModel(storage);
            DataContext = viewModel;
        }
    }
}
