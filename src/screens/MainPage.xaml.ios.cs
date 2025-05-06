namespace All_Inclusive;

#if IOS
using UIKit;
using Microsoft.Maui.Platform;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();

        Loaded += (_, _) =>
        {
            var nativeView = FormContainer.Handler.PlatformView as UIView;
            if (nativeView != null)
            {
                nativeView.IsAccessibilityElement = true;
                nativeView.AccessibilityLabel = "User registration form";
                nativeView.AccessibilityTraits |= UIAccessibilityTrait.Header; // acts like ARIA role="form"
            }
        };
    }
}
#endif
