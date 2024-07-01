namespace EagleEye.Controls;

public partial class ColorItemView : ContentView
{
    public static readonly BindableProperty ColorProperty =
        BindableProperty.Create(nameof(Color), typeof(Color), typeof(ColorItemView), new Microsoft.Maui.Graphics.Color(255, 255, 255, 255));
    public static readonly BindableProperty TextProperty =
        BindableProperty.Create(nameof(Text), typeof(string), typeof(ColorItemView), "test");
    public static readonly BindableProperty NumberProperty =
        BindableProperty.Create(nameof(Number), typeof(string), typeof(ColorItemView), "0");
    public static readonly BindableProperty MaxValueProperty =
        BindableProperty.Create(nameof(MaxValue), typeof(int), typeof(ColorItemView), int.MaxValue);


    public ColorItemView()
    {
        InitializeComponent();
    }

    public Color Color
    {
        get => (Color) GetValue(ColorProperty);
        set => SetValue(ColorProperty,value);
    }

    public int MaxValue
    {
        get => (int)GetValue(MaxValueProperty);
        set => SetValue(MaxValueProperty, value);
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

    private void Entry_TextChanged(object sender, TextChangedEventArgs e)
    {
        var entry = sender as Entry;
        if (entry == null)
            return;

        var newText = new string(entry.Text.Where(char.IsDigit).ToArray());
        if(string.IsNullOrEmpty(newText))
        {
            entry.Text = "0";
            return;
        }

        int n = int.Parse(newText);

        if (n >= MaxValue)
            entry.Text = MaxValue.ToString();
        else
            entry.Text = n.ToString();
    }
}