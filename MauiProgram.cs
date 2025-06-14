﻿#if ANDROID
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
            
            nativeLabel.SetAccessibilityDelegate(new SuppressActionHintDelegate());
#endif
        });

        return builder.Build();
    }
}

#if ANDROID

class SuppressActionHintDelegate : Android.Views.View.AccessibilityDelegate
{
    public override void OnInitializeAccessibilityNodeInfo(Android.Views.View host, Android.Views.Accessibility.AccessibilityNodeInfo info)
    {
        base.OnInitializeAccessibilityNodeInfo(host, info);

        // Trick TalkBack: keep it focusable but not clickable
        info.Focusable = true;
        info.ActionList?.Clear();
    }
}

#endif