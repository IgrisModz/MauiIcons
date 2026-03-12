using AndroidX.AppCompat.Widget;
using MauiIcons.Core.Controls;

namespace MauiIcons.Core.Handlers;

/// <summary>
/// Handles the application of variable font icon variations to the platform-specific view.
/// </summary>
/// <remarks>This handler is responsible for updating font variation settings, such as weight, fill, grade, and
/// optical size, on supported Android versions (API 26 and above). It interacts with views implementing the
/// IVariableIcon interface to reflect the desired icon appearance. This class is typically used in custom controls that
/// require dynamic icon styling based on variable font features.</remarks>
public partial class VariableIconHandler
{
	partial void ApplyVariations()
	{
		if (PlatformView is not AppCompatTextView platformView)
		{
			return;
		}

		if (VirtualView is not IVariableIcon icon)
		{
			return;
		}

		if (OperatingSystem.IsAndroidVersionAtLeast(26)) // Font variation settings require API 26+
		{
			platformView.SetFontVariationSettings(
				$"'wght' {icon.Weight}, 'FILL' {icon.Fill}, 'GRAD' {icon.Grade}, 'opsz' {icon.OpticalSize}");
		}
	}
}