using CommunityToolkit.Maui;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessApp.ViewModels
{
    public partial class WeighinPopupViewModel : BaseViewModel
    {
        private IPopupService _popupService;

        [ObservableProperty]
        private decimal _currentWeight;

        [ObservableProperty]
        private decimal _currentWaist;

        public WeighinPopupViewModel(IPopupService popupService)
        {
            _popupService = popupService;
        }


        [RelayCommand]
        private async Task OnCancel()
        {
            await _popupService.ClosePopupAsync(Shell.Current);
        }

        [RelayCommand]
        private async Task OnSave()
        {
            // Need to pass the wieghin information back
            await _popupService.ClosePopupAsync(Shell.Current);
        }
    }
}
