using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using TesteKryptusMVVM.ViewModels;

namespace TesteKryptusMVVM.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel() {TextError = "fkdlsdkflsd" };
            this.AttachDevTools();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public void teste(object sender, RoutedEventArgs e)
        {

        }

        public void OnLoginClick(object sender, RoutedEventArgs e)
        {
            var context = this.DataContext as MainWindowViewModel;
            string usuario = "admin";
            string senha = "Admin123!";

            if (context.User == usuario && context.Password == senha)
            {
                Dashboard dashboard = new Dashboard();
                dashboard.Show();
                this.Hide();
                context.TextError = "";
            }
            else
            {
                context.TextError = "Usuário e/ou senha incorreto(s)";
            }
        }
    }
}
