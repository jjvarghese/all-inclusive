using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_Inclusive.views;

public partial class FormField : ContentView
{
    public static readonly BindableProperty TitleProperty = BindableProperty.Create("Title", typeof(string), typeof(FormField), null);
    public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create("Placeholder", typeof(string), typeof(FormField), null);
    public static readonly BindableProperty DescriptionProperty = BindableProperty.Create("Description", typeof(string), typeof(FormField), null);
    public static readonly BindableProperty KeyboardProperty = BindableProperty.Create("Keyboard", typeof(Keyboard), typeof(FormField), Keyboard.Default);
    public static readonly BindableProperty TextProperty =
        BindableProperty.Create(nameof(Text), typeof(string), typeof(FormField), null, BindingMode.TwoWay);

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }
    
    public String Title
    {
        get { return (String)GetValue(TitleProperty); }
        set { SetValue(TitleProperty, value); }
    }

    public String Placeholder
    {
        get { return (String)GetValue(PlaceholderProperty); }
        set { SetValue(PlaceholderProperty, value); }
    }

    public String Description
    {
        get { return (String)GetValue(DescriptionProperty); }
        set { SetValue(DescriptionProperty, value); }
    }

    public Keyboard Keyboard
    {
        get { return (Keyboard)GetValue(KeyboardProperty); }
        set { SetValue(KeyboardProperty, value); }
    }
    
    public FormField()
    {
        InitializeComponent();
        
        BindingContext = this;
    }
}