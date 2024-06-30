using EagleEye.ViewModels;

namespace EagleEye.GamePages;

public partial class RememberColorGamePage : ContentPage
{
	public RememberColorGamePage(RememberColorGameViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}