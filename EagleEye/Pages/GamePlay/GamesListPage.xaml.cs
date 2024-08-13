using EagleEye.ViewModels.GamePlay;

namespace EagleEye.Pages.GamePlay;

public partial class GamesListPage : ContentPage
{
	public GamesListPage(GamesListViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}