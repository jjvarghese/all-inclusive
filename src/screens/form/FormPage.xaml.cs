using All_Inclusive.screens.form;
using Microsoft.Maui.Controls;

namespace All_Inclusive;

public partial class FormPage : ContentPage
{
    public FormPage()
    {
        InitializeComponent();
        BindingContext = new FormViewModel();

#if ANDROID
        Loaded += (_, _) =>
        {
            var nativeView = FormContainer?.Handler?.PlatformView as Android.Views.View;
            if (nativeView != null)
            {
                nativeView.ContentDescription = "User registration form";
                nativeView.ImportantForAccessibility = Android.Views.ImportantForAccessibility.Yes;
                nativeView.AccessibilityLiveRegion = Android.Views.AccessibilityLiveRegion.Assertive;
            }
        };
#endif

#if IOS
        Loaded += (_, _) =>
        {
            var nativeView = FormContainer?.Handler?.PlatformView as UIKit.UIView;
            if (nativeView != null)
            {
                nativeView.IsAccessibilityElement = true;
                nativeView.AccessibilityLabel = "User registration form";
                nativeView.AccessibilityTraits |= UIKit.UIAccessibilityTrait.Header;
            }
        };
#endif
    }
}