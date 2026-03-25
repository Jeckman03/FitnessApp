using CommunityToolkit.Maui.Views;
using FitnessApp.ViewModels;

namespace FitnessApp.Views;

public partial class WeighinPopupPage : Popup
{
	public WeighinPopupPage(WeighinPopupViewModel weighinPopupViewModel)
	{
		InitializeComponent();
		BindingContext = weighinPopupViewModel;
	}
}