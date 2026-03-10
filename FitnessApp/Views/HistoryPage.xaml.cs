using FitnessApp.ViewModels;

namespace FitnessApp.Views;

public partial class HistoryPage : ContentPage
{
	public HistoryPage(HistoryViewModel historyViewModel)
	{
		InitializeComponent();
		BindingContext = historyViewModel;
	}
}