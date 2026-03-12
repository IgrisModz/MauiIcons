using UIKit;
using Foundation;
using Microsoft.Maui.Platform;
using MauiIcons.Core.Controls;

namespace MauiIcons.Core.Handlers;

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