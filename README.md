
# IgrisModz.MauiIcons 🚀

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
![.NET Version](https://img.shields.io/badge/.NET-10.0-purple.svg)
![Platform](https://img.shields.io/badge/Platform-MAUI-blue.svg)

A powerful, modular, and high-performance suite of libraries for **.NET MAUI** (.NET 10). It allows you to seamlessly integrate thousands of standard and **Variable Font** icons with native support for XAML, Markup Extensions, animations, and Data Binding.

---

## 📦 Available NuGet Packages

Our ecosystem is fully modular. You only need to install the specific packages that match your design requirements. 

| Package | Latest Version | Description |
| :--- | :--- | :--- |
| `IgrisModz.MauiIcons.Core` | [![NuGet](https://img.shields.io/nuget/v/IgrisModz.MauiIcons.Core.svg)](https://www.nuget.org/packages/IgrisModz.MauiIcons.Core/) | The foundational logic (Animations, Extensions). *Automatically installed with any icon pack.* |
| `IgrisModz.MauiIcons.FontAwesome.Brands` | [![NuGet](https://img.shields.io/nuget/v/IgrisModz.MauiIcons.FontAwesome.Brands.svg)](https://www.nuget.org/packages/IgrisModz.MauiIcons.FontAwesome.Brands/) | Official logos for social media and global brands (FontAwesome 7.2.0 Free). |
| `IgrisModz.MauiIcons.FontAwesome.Regular` | [![NuGet](https://img.shields.io/nuget/v/IgrisModz.MauiIcons.FontAwesome.Regular.svg)](https://www.nuget.org/packages/IgrisModz.MauiIcons.FontAwesome.Regular/) | Balanced, outlined style for a clean UI (FontAwesome 7.2.0 Free). |
| `IgrisModz.MauiIcons.FontAwesome.Solid` | [![NuGet](https://img.shields.io/nuget/v/IgrisModz.MauiIcons.FontAwesome.Solid.svg)](https://www.nuget.org/packages/IgrisModz.MauiIcons.FontAwesome.Solid/) | Heavy, filled icons for high visibility (FontAwesome 7.2.0 Free). |
| `IgrisModz.MauiIcons.Material.Outlined` | [![NuGet](https://img.shields.io/nuget/v/IgrisModz.MauiIcons.Material.Outlined.svg)](https://www.nuget.org/packages/IgrisModz.MauiIcons.Material.Outlined/) | Modern Google Material design with thin strokes (Material Icons 4.0.0). |
| `IgrisModz.MauiIcons.Material.Regular` | [![NuGet](https://img.shields.io/nuget/v/IgrisModz.MauiIcons.Material.Regular.svg)](https://www.nuget.org/packages/IgrisModz.MauiIcons.Material.Regular/) | Standard Material filled icons for a native Android look. |
| `IgrisModz.MauiIcons.Material.Round` | [![NuGet](https://img.shields.io/nuget/v/IgrisModz.MauiIcons.Material.Round.svg)](https://www.nuget.org/packages/IgrisModz.MauiIcons.Material.Round/) | Material icons with softened, rounded corners for a friendly vibe. |
| `IgrisModz.MauiIcons.Material.Sharp` | [![NuGet](https://img.shields.io/nuget/v/IgrisModz.MauiIcons.Material.Sharp.svg)](https://www.nuget.org/packages/IgrisModz.MauiIcons.Material.Sharp/) | Crisp, geometric edges for a precise and professional look. |
| `IgrisModz.MauiIcons.Material.TwoTone` | [![NuGet](https://img.shields.io/nuget/v/IgrisModz.MauiIcons.Material.TwoTone.svg)](https://www.nuget.org/packages/IgrisModz.MauiIcons.Material.TwoTone/) | Multi-dimensional look featuring distinct layered outlines and fills. |
| `IgrisModz.MauiIcons.MaterialSymbols.Outlined` | [![NuGet](https://img.shields.io/nuget/v/IgrisModz.MauiIcons.MaterialSymbols.Outlined.svg)](https://www.nuget.org/packages/IgrisModz.MauiIcons.MaterialSymbols.Outlined/) | **[Variable Font]** Highly customizable Material Symbols (Outlined). |
| `IgrisModz.MauiIcons.MaterialSymbols.Rounded` | [![NuGet](https://img.shields.io/nuget/v/IgrisModz.MauiIcons.MaterialSymbols.Rounded.svg)](https://www.nuget.org/packages/IgrisModz.MauiIcons.MaterialSymbols.Rounded/) | **[Variable Font]** Highly customizable Material Symbols (Rounded). |
| `IgrisModz.MauiIcons.MaterialSymbols.Sharp` | [![NuGet](https://img.shields.io/nuget/v/IgrisModz.MauiIcons.MaterialSymbols.Sharp.svg)](https://www.nuget.org/packages/IgrisModz.MauiIcons.MaterialSymbols.Sharp/) | **[Variable Font]** Highly customizable Material Symbols (Sharp). |

---

## 🛠 Configuration

In your `MauiProgram.cs`, register the icon fonts for the packages you have installed:

```csharp
using MauiIcons.FontAwesome.Brands;
using MauiIcons.Material.Outlined;
using MauiIcons.MaterialSymbols.Rounded;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            // Register only the packages you need
            .UseFontAwesomeBrands()
            .UseMaterialOutlined()
            .UseMaterialSymbolsRounded(); 

        return builder.Build();
    }
}

```

---

## 🚀 Usage

### 1. XAML Namespace Declaration

Use this single namespace to access the entire IgrisModz suite, regardless of how many packages you installed:

```xml
xmlns:mi="[http://www.igrismodz.com/dotnet/2026/maui/icons](http://www.igrismodz.com/dotnet/2026/maui/icons)"

```

### 2. Standard Icons (FontAwesome & Material Icons)

Use built-in controls or Markup Extensions for standard static fonts:

```xml
<mi:FontAwesomeSolidIcon Icon="Heart" TextColor="Red" FontSize="40" Animation="Pulse" IsAnimationActive="True" />

<Label Text="{mi:FontAwesomeBrands Icon=Apple, Size=60, Color=DarkBlue}" />
<Button Text="{mi:FontAwesomeBrands Icon=Twitter, Size=30, Color=SkyBlue}" />

```

### 3. Variable Font Icons (Material Symbols) ⚠️

The `MaterialSymbols.*` packages utilize **Variable Font** technology. To access variable axes (like `Weight` or `Fill`), you **must** use the dedicated icon control or wrap it in a View container (`ContentView`, `SwipeView`).

```xml
<mi:MaterialSymbolsRoundedIcon Icon="Search" 
                               TextColor="Blue" 
                               FontSize="40" 
                               Weight="700" 
                               Fill="True" />

```

*Platform Constraint:* The `Weight` axis works on all platforms. However, axes like `Fill`, `Grade`, and `OpticalSize` currently **only work on Android and iOS** (Not supported on Windows/WinUI).

### 4. Platform Specific Support

Display different icons based on the target OS automatically:

```xml
<mi:FontAwesomeBrandsIcon Icon="{mi:FontAwesomeBrandsPlatform WinUI=Youtube, Android=Discord, iOS=GitHub}" 
                          FontSize="60" 
                          TextColor="Red" />

```

---

## 🎨 Key Features

* **Variable Fonts Support:** Dynamically adjust Weight, Fill, Grade, and OpticalSize on supported platforms (Material Symbols only).
* **Animations:** Native support for `Spin`, `Shake`, `Rotate`, `Pulse`, etc., via the `Animation` property.
* **Data Binding:** All properties (`Icon`, `Color`, `Size`, `Animation`, `Weight`) are fully bindable.
* **Typing Safety:** Powered by C# Enums. No more magic strings!
* **C# Usage:**
```csharp
var facebookIcon = new FontAwesomeBrandsIcon
{
    Icon = FontAwesomeBrandsIcons.Facebook,
    TextColor = Colors.Blue,
    FontSize = 40
};

```



---

## ⚠️ Notes & Limitations

* **Animation Compatibility:** Animations may not work on all standard controls (e.g., `Image`). On a `Button`, the animation will apply to the entire control rather than just the icon glyph.
* **Markup Extensions vs Variable Fonts:** Standard controls (like `Label`) using Markup Extensions can render Variable Fonts, but **cannot** apply custom variable axes like `Weight` or `Fill`. They will use the default font style.
* **Core Library:** You rarely need to call `.UseMauiIconsCore()`, unless you are building your own custom icon library on top of our framework.

---

## 📄 License & Disclaimer

This project is licensed under the **MIT License**.

**Disclaimer:** This library is not affiliated with or endorsed by FontAwesome or Google (Material Design). The icons provided are based on their respective free/open-source icon sets. Please refer to their official websites for original icon licensing information.

---

*Developed with ❤️ by IgrisModz for the .NET MAUI community.*