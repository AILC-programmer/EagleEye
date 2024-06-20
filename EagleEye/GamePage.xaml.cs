using EagleEye.ViewModels;

namespace EagleEye;

public partial class GamePage : ContentPage
{
	public GamePage(GameViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}