#if ANDROID
using Android.Views;
using Android.Views.Accessibility;
using Android.Widget;
#endif

using Microsoft.Maui.Handlers;

namespace All_Inclusive;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        LabelHandler.Mapper.AppendToMapping("SuppressTalkBackHint", (handler, view) =>
        {
#if ANDROID
    var nativeLabel = handler.PlatformView;
    nativeLabel.Clickable = true;

    nativeLabel.SetAccessibilityDelegate(new SuppressActionHintDelegate());
#endif
        });

        return builder.Build();
    }
}

#if ANDROID

class SuppressActionHintDelegate : Android.Views.View.AccessibilityDelegate
{
    public override void OnInitializeAccessibilityNodeInfo(Android.Views.View host, AccessibilityNodeInfo info)
    {
        base.OnInitializeAccessibilityNodeInfo(host, info);

        // Clear action list
        info.ActionList?.Clear();

        // Optional: prevent it from being seen as a Button
        info.ClassName = Java.Lang.Class.FromType(typeof(TextView)).CanonicalName;
    }
}
#endif