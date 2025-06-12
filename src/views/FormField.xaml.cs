using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using All_Inclusive.screens.form;

namespace All_Inclusive.views;

public partial class FormField : ContentView
{
    public static readonly BindableProperty TitleProperty = BindableProperty.Create(
        nameof(Title), typeof(string), typeof(FormField), default(string));
    public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(nameof(Placeholder), typeof(string), typeof(FormField), null);
    public static readonly BindableProperty DescriptionProperty = BindableProperty.Create(nameof(Description), typeof(string), typeof(FormField), null);
    public static readonly BindableProperty KeyboardTypeProperty = BindableProperty.Create(nameof(KeyboardType), typeof(Keyboard), typeof(FormField), Keyboard.Default);

    public static readonly BindableProperty FieldMetadataProperty =
        BindableProperty.Create(nameof(FieldMetadata), typeof(FormMetadata), typeof(FormField), null, propertyChanged: OnFieldMetadataChanged);
    
    public FormMetadata FieldMetadata
    {
        get => (FormMetadata)GetValue(FieldMetadataProperty);
        set => SetValue(FieldMetadataProperty, value);
    }

    private static void OnFieldMetadataChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is FormField formField && newValue is FormMetadata metadata)
        {
            formField.Title = metadata.Title;
            formField.Placeholder = metadata.Placeholder;
            formField.Description = metadata.Description;
            formField.KeyboardType = metadata.Keyboard;
        }
    }
    
    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }
    public string Placeholder
    {
        get => (string)GetValue(PlaceholderProperty);
        set => SetValue(PlaceholderProperty, value);
    }

    public string Description
    {
        get => (string)GetValue(DescriptionProperty);
        set => SetValue(DescriptionProperty, value);
    }

    public Keyboard KeyboardType
    {
        get => (Keyboard)GetValue(KeyboardTypeProperty);
        set => SetValue(KeyboardTypeProperty, value);
    }

    public FormField()
    {
        InitializeComponent();
    }
}
