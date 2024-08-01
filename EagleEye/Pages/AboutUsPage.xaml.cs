using EagleEye.ViewModels;

namespace EagleEye.Pages;

public partial class AboutUsPage : ContentPage
{
	public AboutUsPage(AboutUsViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}