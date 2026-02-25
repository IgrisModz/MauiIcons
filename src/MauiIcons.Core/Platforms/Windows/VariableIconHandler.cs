using MauiIcons.Core.Controls;
using Microsoft.Maui.Handlers;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Documents;
using FontWeight = Windows.UI.Text.FontWeight;

namespace MauiIcons.Core.Platforms.Windows;
public class VariableIconHandler : LabelHandler
{
    protected override void ConnectHandler(TextBlock platformView)
    {
        base.ConnectHandler(platformView);
        ApplyVariations(platformView);
    }

    public override void UpdateValue(string property)
    {
        base.UpdateValue(property);
        ApplyVariations(PlatformView);
    }

    private void ApplyVariations(TextBlock platformView)
    {
        if (VirtualView is not IVariableIcon icon)
            return;

        platformView.FontWeight = new FontWeight
        {
            Weight = (ushort)Math.Clamp(icon.Weight, FontWeights.Thin, FontWeights.Black)
        };
    }
}