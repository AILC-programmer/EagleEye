using EagleEye.ViewModels;

namespace EagleEye;

public partial class SettingsPage : ContentPage
{
	public SettingsPage(SettingsViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}