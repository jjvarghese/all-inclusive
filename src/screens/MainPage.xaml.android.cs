namespace All_Inclusive;

#if ANDROID
using Android.Views;
using Microsoft.Maui.Platform;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();

        Loaded += (_, _) =>
        {
            var nativeView = FormContainer.Handler.PlatformView as View;
            if (nativeView != null)
            {
                nativeView.ContentDescription = "User registration form";
                nativeView.ImportantForAccessibility = ImportantForAccessibility.Yes;
                nativeView.AccessibilityLiveRegion = AccessibilityLiveRegion.Assertive;
            }
        };
    }
}
#endif
