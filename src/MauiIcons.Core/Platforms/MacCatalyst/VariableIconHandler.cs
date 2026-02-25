using UIKit;
using Foundation;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using MauiIcons.Core.Controls;

namespace MauiIcons.Core.Platforms.MacCatalyst;

public class VariableIconHandler : LabelHandler
{
    protected override void ConnectHandler(MauiLabel platformView)
    {
        base.ConnectHandler(platformView);
        ApplyVariations(platformView);
    }

    public override void UpdateValue(string property)
    {
        base.UpdateValue(property);
        ApplyVariations(PlatformView);
    }

    private void ApplyVariations(MauiLabel platformView)
    {
        if (VirtualView is not IVariableIcon icon)
            return;

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
            [new NSString("NSFontVariationAttribute")] // À remplacer par la clé correcte
        );
        var descriptor = platformView.Font.FontDescriptor.CreateWithAttributes(attributesDict);
        platformView.Font = UIFont.FromDescriptor(descriptor, platformView.Font.PointSize);
    }
}