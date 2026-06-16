using FitnessApp.ViewModels;

namespace FitnessApp
{
    public partial class MainPage : ContentPage
    {
        private readonly MainPageViewModel _mainPageViewModel;

        public MainPage(MainPageViewModel mainPageViewModel)
        {
            InitializeComponent();
            BindingContext = mainPageViewModel;
            _mainPageViewModel = mainPageViewModel;
        }

        protected override async void OnNavigatedTo(NavigatedToEventArgs args)
        {
            base.OnNavigatedTo(args);

            await _mainPageViewModel.LoadDashboardDataAsync();
        }
    }
}
