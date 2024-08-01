﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EagleEye.Models;
using EagleEye.Pages;
using EagleEye.Tools;

namespace EagleEye.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        public MainViewModel()
        {
            LoadModel();
        }

        [ObservableProperty]
        UserModel user = new UserModel();

        [RelayCommand]
        async Task GoToSettings() => await AppShell.Current.GoToAsync(nameof(SettingsPage));

        [RelayCommand]
        async Task GoToAboutUs() => await AppShell.Current.GoToAsync(nameof(AboutUsPage));

        void LoadModel()
        {
            var result = ObjectSerializer.DeserializeObject<UserModel>(PathWorker.Instance.GetUserFilePath);
            if (result != null)
                User = result;
            else
                User = new Models.UserModel();
        }

    }
}
