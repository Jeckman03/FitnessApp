using FitnessApp.ViewModels;

namespace FitnessApp.Views;

public partial class WorkoutPage : ContentPage
{
	public WorkoutPage(WorkoutViewModel workoutViewModel)
	{
		InitializeComponent();
		BindingContext = workoutViewModel;
	}
}