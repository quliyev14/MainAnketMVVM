using AnketMVVM.ViewModels;
using System.Windows;

namespace AnketMVVM.Views
{
    /// <summary>
    /// Interaction logic for MainViews.xaml
    /// </summary>
    public partial class MainViews : Window
    {
        public MainViews()
        {
            InitializeComponent();
            DataContext = new MainViewModels();
        }
    }
}
