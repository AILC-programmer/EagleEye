using EagleEye.Settings;
using EagleEye.ViewModels;

namespace EagleEye.Pages;

public partial class SettingsPage : ContentPage
{
	public SettingsPage(SettingsViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}