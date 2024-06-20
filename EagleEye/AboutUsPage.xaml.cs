using EagleEye.ViewModels;

namespace EagleEye;

public partial class AboutUsPage : ContentPage
{
	public AboutUsPage(AboutUsVIewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}