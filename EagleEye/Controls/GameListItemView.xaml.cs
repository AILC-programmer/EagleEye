namespace EagleEye.Controls;

public partial class GameListItemView : ContentView
{
	public GameListItemView()
	{
		InitializeComponent();
	}
	
	public string Text
	{
		get => TitleLabel.Text;
		set => TitleLabel.Text = value;
	}
}