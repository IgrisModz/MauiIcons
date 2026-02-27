# IgrisModz.MauiIcons 🚀

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
![.NET Version](https://img.shields.io/badge/.NET-10.0-purple.svg)
![Platform](https://img.shields.io/badge/Platform-MAUI-blue.svg)

A powerful and modular suite of libraries for **.NET MAUI** (.NET 10) that allows you to integrate thousands of icons with native support for XAML, Markup Extensions, animations, and Data Binding.

---

## 📦 Available NuGet Packages

Each package is independent. Install only the ones that match your design needs:

| Package | Latest Version | Description |
| :--- | :--- | :--- |
| `IgrisModz.MauiIcons.FontAwesome.Brands` | [![NuGet](https://img.shields.io/nuget/v/IgrisModz.MauiIcons.FontAwesome.Brands.svg)](https://www.nuget.org/packages/IgrisModz.MauiIcons.FontAwesome.Brands/) | Official logos for social media and global brands (FontAwesome 7.2.0 Free). |
| `IgrisModz.MauiIcons.FontAwesome.Regular` | [![NuGet](https://img.shields.io/nuget/v/IgrisModz.MauiIcons.FontAwesome.Regular.svg)](https://www.nuget.org/packages/IgrisModz.MauiIcons.FontAwesome.Regular/) | Balanced, outlined style for a clean UI (FontAwesome 7.2.0 Free). |
| `IgrisModz.MauiIcons.FontAwesome.Solid` | [![NuGet](https://img.shields.io/nuget/v/IgrisModz.MauiIcons.FontAwesome.Solid.svg)](https://www.nuget.org/packages/IgrisModz.MauiIcons.FontAwesome.Solid/) | Heavy, filled icons for high visibility (FontAwesome 7.2.0 Free). |
| `IgrisModz.MauiIcons.Material.Outlined` | [![NuGet](https://img.shields.io/nuget/v/IgrisModz.MauiIcons.Material.Outlined.svg)](https://www.nuget.org/packages/IgrisModz.MauiIcons.Material.Outlined/) | Modern Google Material design with thin strokes (Material 4.0.0). |
| `IgrisModz.MauiIcons.Material.Regular` | [![NuGet](https://img.shields.io/nuget/v/IgrisModz.MauiIcons.Material.Regular.svg)](https://www.nuget.org/packages/IgrisModz.MauiIcons.Material.Regular/) | Standard Material filled icons for a native Android look. |
| `IgrisModz.MauiIcons.Material.Round` | [![NuGet](https://img.shields.io/nuget/v/IgrisModz.MauiIcons.Material.Round.svg)](https://www.nuget.org/packages/IgrisModz.MauiIcons.Material.Round/) | Material icons with softened, rounded corners for a friendly vibe. |
| `IgrisModz.MauiIcons.Material.Sharp` | [![NuGet](https://img.shields.io/nuget/v/IgrisModz.MauiIcons.Material.Sharp.svg)](https://www.nuget.org/packages/IgrisModz.MauiIcons.Material.Sharp/) | Crisp, geometric edges for a precise and professional look. |
| `IgrisModz.MauiIcons.Material.TwoTone` | [![NuGet](https://img.shields.io/nuget/v/IgrisModz.MauiIcons.Material.TwoTone.svg)](https://www.nuget.org/packages/IgrisModz.MauiIcons.Material.TwoTone/) | Multi-dimensional look featuring distinct layered outlines and fills. |

---

## 🛠 Configuration

In your `MauiProgram.cs`, register the icon fonts for the packages you have installed:

```csharp
using MauiIcons.FontAwesome.Brands;
using MauiIcons.Material.Outlined;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            // Register only the packages you need
            .UseFontAwesomeBrands()
            .UseMaterialOutlined();

        return builder.Build();
    }
}
```

---

## 🚀 Usage

### 1. XAML Namespace Declaration

Use this single namespace to access the entire IgrisModz suite:

```xml
xmlns:mi="http://www.igrismodz.com/dotnet/2026/maui/icons"
```

### 2. Built-in Icon Controls

```xml
<mi:FontAwesomeSolidIcon Icon="Heart" 
                         TextColor="Blue" 
                         FontSize="40" 
                         Animation="Pulse" 
                         IsAnimationActive="True" />
```

### 3. XAML Markup Extensions

Inject icons directly into standard MAUI control properties like `Text` or `Source`:

```xml
<Label Text="{mi:FontAwesomeBrands Icon=Apple, Size=60, Color=DarkBlue}" />
<Button Text="{mi:FontAwesomeBrands Icon=Twitter, Size=30, Color=SkyBlue}" />
<Image Source="{mi:FontAwesomeBrands Icon=Github, Size=50, Color=Black}" Aspect="Center" />
```

### 4. Platform Specific Support

Display different icons based on the target OS:

```xml
<mi:FontAwesomeBrandsIcon Icon="{mi:FontAwesomeBrandsPlatform WinUI=Youtube, Android=Discord, iOS=GitHub}" 
                          FontSize="60" 
                          TextColor="Red" />

<Label>
    <Label.Text>
        <mi:FontAwesomeBrands Size="60" Color="RosyBrown" Animation="Spin" IsAnimationActive="True">
            <mi:FontAwesomeBrands.Icon>
                <mi:FontAwesomeBrandsPlatform WinUI="Airbnb" Android="Google" />
            </mi:FontAwesomeBrands.Icon>
        </mi:FontAwesomeBrands>
    </Label.Text>
</Label>
```

---

## 🎨 Key Features

* **Animations:** Native support for `Spin`, `Shake`, `Rotate`, etc., via `Animation` and `IsAnimationActive` properties.
* **Data Binding:** All properties (Icon, Color, Size, Animation) are *Bindable Properties*.
* **C# Usage:**
```csharp
using MauiIcons.FontAwesome.Brands;

var facebookIcon = new FontAwesomeBrandsIcon
{
    Icon = FontAwesomeBrandsIcons.Facebook,
    TextColor = Colors.Blue,
    FontSize = 40
};
```

---

## ⚠️ Notes & Limitations

* **Animation Compatibility:** Animations may not work on all controls (e.g., `Image`). On a `Button`, the animation will apply to the entire control rather than just the icon glyph.
* **Direct Font Usage:** If the font is registered, you can still use the FontFamily manually:
`<Label Text="&#xf024;" FontFamily="FontAwesomeBrands" />`

---

## 📄 License & Disclaimer

This project is licensed under the **MIT License**.

**Disclaimer:** This library is not affiliated with or endorsed by FontAwesome or Google (Material Design). The icons provided are based on their respective free icon sets. Please refer to their official websites for original icon licensing information.

---

*Developed with ❤️ by IgrisModz for the .NET MAUI community.*