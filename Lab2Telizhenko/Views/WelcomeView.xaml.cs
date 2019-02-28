using Lab2Telizhenko.Models;
using Lab2Telizhenko.ViewModels;
using System.Windows.Controls;

namespace Lab2Telizhenko.Views
{
    /// <summary>
    /// Логика взаимодействия для WelcomeView.xaml
    /// </summary>
    public partial class WelcomeView : UserControl
    {
        public WelcomeView(Storage storage)
        {
            InitializeComponent();
            var viewModel = new WelcomeViewModel(storage);
            DataContext = viewModel;
        }
    }
}
