using UIKit;
using Foundation;
using Microsoft.Maui.Platform;
using MauiIcons.Core.Controls;

namespace MauiIcons.Core.Handlers;

/// <summary>
/// Handles the application of variable font icon variations to a platform-specific label control.
/// </summary>
/// <remarks>This handler is responsible for updating the font attributes of a label based on the properties
/// defined by an associated variable icon. It ensures that the correct font variations, such as weight, fill, grade,
/// and optical size, are applied to the label's font descriptor. This class is typically used in scenarios where
/// dynamic icon appearance is required based on variable font features.</remarks>
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