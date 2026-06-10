using FitnessApp.ViewModels;

namespace FitnessApp.Views;

public partial class CreatePlanPage : ContentPage
{

    public CreatePlanPage(CreatePlanViewModel createPlanViewModel)
	{
		InitializeComponent();
        BindingContext = createPlanViewModel;
    }
}