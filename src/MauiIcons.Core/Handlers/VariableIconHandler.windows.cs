using MauiIcons.Core.Controls;
using Microsoft.Maui.Handlers;
using Microsoft.UI.Xaml.Controls;
using FontWeight = Windows.UI.Text.FontWeight;
using FontWeights = Microsoft.UI.Text.FontWeights;

namespace MauiIcons.Core.Handlers;

public partial class VariableIconHandler
{
    partial void ApplyVariations()
    {
        if (PlatformView is not TextBlock platformView)
		{
			return;
		}

		if (VirtualView is not IVariableIcon icon)
		{
			return;
		}

		platformView.FontWeight = new FontWeight
        {
            Weight = (ushort)Math.Clamp(icon.Weight, FontWeights.Thin.Weight, FontWeights.Black.Weight)
        };
    }
}