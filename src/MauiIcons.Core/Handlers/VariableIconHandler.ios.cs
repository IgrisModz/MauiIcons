using UIKit;
using Foundation;
using Microsoft.Maui.Platform;
using MauiIcons.Core.Controls;

namespace MauiIcons.Core.Handlers;

/// <summary>
/// Handles the application of variable font icon variations to a platform-specific label control.
/// </summary>
/// <remarks>This class is responsible for updating the font attributes of a label based on the properties defined
/// by an associated variable icon. It is typically used in scenarios where icon appearance needs to be dynamically
/// adjusted according to weight, fill, grade, or optical size variations. This handler is intended for internal use
/// within the UI rendering pipeline and is not intended to be used directly by application code.</remarks>
public partial class VariableIconHandler
{
	partial void ApplyVariations()
	{
		if (PlatformView is not MauiLabel platformView)
		{
			return;
		}

		if (VirtualView is not IVariableIcon icon)
		{
			return;
		}

		var variation = NSDictionary.FromObjectsAndKeys(
			[
				NSNumber.FromInt32(icon.Weight),
				NSNumber.FromInt32(icon.Fill),
				NSNumber.FromInt32(icon.Grade),
				NSNumber.FromInt32(icon.OpticalSize)
			],
			[
				new NSString("wght"),
				new NSString("FILL"),
				new NSString("GRAD"),
				new NSString("opsz")
			]);

		var attributesDict = NSDictionary.FromObjectsAndKeys(
			[variation],
			[new NSString("NSFontVariationAttribute")]
		);
		var descriptor = platformView.Font.FontDescriptor.CreateWithAttributes(attributesDict);
		platformView.Font = UIFont.FromDescriptor(descriptor, platformView.Font.PointSize);
	}
}