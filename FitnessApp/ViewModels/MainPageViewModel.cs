using CommunityToolkit.Maui;
using CommunityToolkit.Mvvm.Input;
using FitnessApp.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessApp.ViewModels
{
    public partial class MainPageViewModel : BaseViewModel
    {
        private IPopupService _popupServices;

        public MainPageViewModel(IPopupService popupServices) 
        {
            _popupServices = popupServices;
        }

        [RelayCommand]
        private async Task WeighInPopup()
        {
            var result = await _popupServices.ShowPopupAsync<WeighinPopupPage>(Shell.Current);
        }
    }
}
