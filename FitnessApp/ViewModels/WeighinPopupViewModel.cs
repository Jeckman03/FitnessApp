using CommunityToolkit.Maui;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessApp.ViewModels
{
    public partial class WeighinPopupViewModel : BaseViewModel
    {
        private IPopupService _popupService;

        private async Task ShowWeighinPopup(IPopupService popupService)
        {
            _popupService = popupService;
        }
    }
}
