using AndroidX.AppCompat.Widget;
using MauiIcons.Core.Controls;
using Microsoft.Maui.Handlers;

namespace MauiIcons.Core.Platforms.Android;

public class VariableIconHandler : LabelHandler
{
    protected override void ConnectHandler(AppCompatTextView platformView)
    {
        base.ConnectHandler(platformView);
        ApplyVariations(platformView);
    }

    public override void UpdateValue(string property)
    {
        base.UpdateValue(property);
        ApplyVariations(PlatformView);
    }

    private void ApplyVariations(AppCompatTextView platformView)
    {
        if (VirtualView is not IVariableIcon icon)
            return;

        if (OperatingSystem.IsAndroidVersionAtLeast(26)) // Font variation settings require API 26+
        {
            platformView.SetFontVariationSettings(
                $"'wght' {icon.Weight}, 'FILL' {icon.Fill}, 'GRAD' {icon.Grade}, 'opsz' {icon.OpticalSize}");
        }
    }
}