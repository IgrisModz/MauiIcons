using MauiIcons.Core.Controls;
using Microsoft.UI.Xaml.Controls;
using FontWeight = Windows.UI.Text.FontWeight;
using FontWeights = Microsoft.UI.Text.FontWeights;

namespace MauiIcons.Core.Handlers;

/// <summary>
/// Handles the application of variable icon styling to platform-specific views.
/// </summary>
/// <remarks>This handler is responsible for updating the appearance of icons that support variable font weights
/// or other visual variations. It is typically used in scenarios where icon rendering needs to adapt dynamically based
/// on the icon's properties.</remarks>
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