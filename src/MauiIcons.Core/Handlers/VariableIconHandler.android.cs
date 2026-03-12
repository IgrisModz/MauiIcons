using AndroidX.AppCompat.Widget;
using MauiIcons.Core.Controls;

namespace MauiIcons.Core.Handlers;

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