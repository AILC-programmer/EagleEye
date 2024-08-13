using EagleEye.ViewModels.GamePlay;

namespace EagleEye.Pages.GamePlay;

public partial class RememberColorsPage : ContentPage
{
	public RememberColorsPage(RememberColorsViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}