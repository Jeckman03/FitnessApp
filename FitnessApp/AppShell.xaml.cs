using FitnessApp.Views;

namespace FitnessApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(WeighinPopupPage), typeof(WeighinPopupPage));
        }
    }
}
