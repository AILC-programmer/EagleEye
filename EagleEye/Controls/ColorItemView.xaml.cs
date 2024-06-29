namespace EagleEye.Controls;

public partial class ColorItemView : ContentView
{
    public static readonly BindableProperty ColorProperty =
        BindableProperty.Create(nameof(Color), typeof(Color), typeof(ColorItemView), new Microsoft.Maui.Graphics.Color(255, 255, 255, 255));
    public static readonly BindableProperty TextProperty =
        BindableProperty.Create(nameof(Text), typeof(string), typeof(ColorItemView), "test");
    public static readonly BindableProperty NumberProperty =
        BindableProperty.Create(nameof(Number), typeof(string), typeof(ColorItemView), "0");


    public ColorItemView()
    {
        InitializeComponent();
    }

    public Color Color
    {
        get => (Color) GetValue(ColorProperty);
        set => SetValue(ColorProperty,value);
    }


    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(NumberProperty, value);
    }

    public string Number
    {
        get => (string)GetValue(NumberProperty);
        set => SetValue(NumberProperty,value);
    }
}