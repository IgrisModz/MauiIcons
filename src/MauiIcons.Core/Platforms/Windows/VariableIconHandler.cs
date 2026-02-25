using MauiIcons.Core.Controls;
using Microsoft.Maui.Handlers;
using Microsoft.UI.Xaml.Controls;
using FontWeight = Windows.UI.Text.FontWeight;

namespace MauiIcons.Core.Platforms.Windows;
public class VariableIconHandler : LabelHandler
{
    protected override void ConnectHandler(TextBlock platformView)
    {
        base.ConnectHandler(platformView);

        if (VirtualView is IVariableIcon icon)
        {
            platformView.FontWeight = new FontWeight
            {
                Weight = (ushort)(icon.Weight >= FontWeights.Bold ? FontWeights.Bold : FontWeights.Normal)
            };
        }
    }
}