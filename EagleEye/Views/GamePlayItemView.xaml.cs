using System.Windows.Input;

namespace EagleEye.Views;

public partial class GamePlayItemView : ContentView
{
	public readonly static BindableProperty TitleProperty =
		BindableProperty.Create(nameof(Title), typeof(string), typeof(GamePlayItemView), "Title");
	public readonly static BindableProperty DescriptionProperty =
		BindableProperty.Create(nameof(Description), typeof(string), typeof(GamePlayItemView), "Description");
	public readonly static BindableProperty CommandProperty =
		BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(GamePlayItemView), null);
	public readonly static BindableProperty CommandParameterProperty =
		BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(GamePlayItemView), null);

	public GamePlayItemView()
	{
		InitializeComponent();
	}

	public string Title
	{
		get => (string)GetValue(TitleProperty);
		set => SetValue(TitleProperty, value);
	}

	public string Description
	{
		get => (string)GetValue(DescriptionProperty);
		set => SetValue(DescriptionProperty, value);
	}

	public ICommand Command
	{
		get => (ICommand)GetValue(CommandProperty);
		set => SetValue(CommandProperty, value);
	}

	public object CommandParameter
	{
		get => (object)GetValue(CommandParameterProperty);
		set => SetValue(CommandParameterProperty, value);
	}


    private void TapGestureRecognizer_Tapped_1(object sender, TappedEventArgs e)
    {
        Command.Execute(CommandParameter);

    }
}