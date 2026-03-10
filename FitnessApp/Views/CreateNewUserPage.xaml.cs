using FitnessApp.ViewModels;

namespace FitnessApp.Views;

public partial class CreateNewUserPage : ContentPage
{
	public CreateNewUserPage(CreateNewUserViewModel createNewUserViewModel)
	{
		InitializeComponent();
		BindingContext = createNewUserViewModel;
	}
}