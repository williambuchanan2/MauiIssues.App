using CommunityToolkit.Mvvm.Input;
using MauiIssues.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiIssues.ViewModels
{
    public partial class MainPageVm: BaseViewModel
    {
        [RelayCommand]
        private void KeyboardIssuePressed()
        {
            NavigationUtil.Navigate<KeyboardIssue>();
        }

        [RelayCommand]
        private void CarouselPressed()
        {
            NavigationUtil.Navigate<CarouselIssue>();
        }

    }
}
