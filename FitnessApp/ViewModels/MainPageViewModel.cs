using CommunityToolkit.Maui;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FitnessApp.Views;
using FitnessAppLibrary.Services.Interfaces;
using FitnessAppLibrary.Services.Interfaces.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessApp.ViewModels
{
    public partial class MainPageViewModel : BaseViewModel
    {
        private IPopupService _popupServices;
        private readonly IPlanTrackingService _planTracking;
        private readonly IDailyLogService _dailyLogService;

        [ObservableProperty] private double _startingWeight;
        [ObservableProperty] private double _currentWeight;
        [ObservableProperty] private double _weightLost;
        [ObservableProperty] private int _maintenanceTDEE;
        [ObservableProperty] private int _currentCalories;
        [ObservableProperty] private string _currentDeficit;
        [ObservableProperty] private int _fatGrams;
        [ObservableProperty] private int _carbGrams;
        [ObservableProperty] private int _proteinGrams;
        [ObservableProperty] private double _currentWaist;
        [ObservableProperty] private double _waistInchesLost;
        [ObservableProperty] private bool _isAssessmentDayVisible;

        public MainPageViewModel(IPopupService popupServices, IPlanTrackingService planTracking, IDailyLogService dailyLogService) 
        {
            _popupServices = popupServices;
            _planTracking = planTracking;
            _dailyLogService = dailyLogService;
        }

        public async Task LoadDashboardDataAsync()
        {
            int userId = Preferences.Default.Get("ActiveUserId", 0);

            if (userId == 0)
            {
                await Shell.Current.GoToAsync("//CreateNewUserPage");
                return;
            }

            var activePlan = await _planTracking.GetPlanByUserIdAsync(userId);
            if (activePlan == null) return;

            var firstLog = await _dailyLogService.GetFirstWeighInByPlanIdAsync(activePlan.Id);
            var latestLog = await _dailyLogService.GetLastWeighInByPlanIdAsync(activePlan.Id);

            if (firstLog != null && latestLog != null)
            {
                StartingWeight = firstLog.CurrentWeight;
                CurrentWeight = latestLog.CurrentWeight;
                WeightLost = Math.Round(StartingWeight - CurrentWeight, 1);
                MaintenanceTDEE = activePlan.MaintenanceTDEE;
                CurrentCalories = activePlan.CurrentCalorieTarget;
                int variance = CurrentCalories - MaintenanceTDEE;
                CurrentDeficit = variance > 0 ? $"+{variance}" : $"{variance}";
                FatGrams = latestLog.FatGrams;
                CarbGrams = latestLog.CarbGrams;
                ProteinGrams = latestLog.ProteinGrams;
                CurrentWaist = latestLog.Waist;
                WaistInchesLost = Math.Round(firstLog.Waist - latestLog.Waist, 1);

                CheckIfAssessmentDay(activePlan.StartDate);
            }
        }

        private void CheckIfAssessmentDay(DateOnly planStartDate)
        {
            DateTime start = planStartDate.ToDateTime(TimeOnly.MinValue);
            DateTime today = DateTime.Today;

            int daysOnPlan = (today - start).Days;

            if (daysOnPlan > 0 && daysOnPlan % 7 == 0)
            {
                IsAssessmentDayVisible = true;
            }
            else
            {
                IsAssessmentDayVisible = false;
            }
        }

        [RelayCommand]
        private async Task WeighInPopup()
        {
            var result = await _popupServices.ShowPopupAsync<WeighinPopupPage>(Shell.Current);
        }
    }
}
