
# IgrisModz.MauiIcons.Core ⚙️

[![NuGet](https://img.shields.io/nuget/v/IgrisModz.MauiIcons.Core.svg)](https://www.nuget.org/packages/IgrisModz.MauiIcons.Core/)
![.NET Version](https://img.shields.io/badge/.NET-10.0-purple.svg)
![Platform](https://img.shields.io/badge/Platform-MAUI-blue.svg)

**MauiIcons.Core** is the foundational engine behind the [IgrisModz.MauiIcons](https://github.com/IgrisModz/MauiIcons) suite for .NET 10 MAUI. 

⚠️ **Note:** This package does **NOT** contain any icons by itself. It provides the underlying architecture, animation engines, base controls, markup extensions, and variable font handlers required to build custom icon libraries.

---

## 🎯 Why use MauiIcons.Core?

If you have a custom corporate font, an SVG-converted `.ttf` file, or a premium icon pack, you can use `MauiIcons.Core` to quickly wrap it into a fully functional .NET MAUI library. 

By building on top of Core, your custom icons will automatically inherit:
* Native **XAML Markup Extensions** support.
* Built-in **Animations** (`Spin`, `Shake`, `Pulse`, etc.).
* **Data Binding** & MVVM compatibility.
* **Platform-specific** icon rendering.
* **Variable Font** axes support (Weight, Fill, etc.).

---

## 🚀 Getting Started

### 1. Installation
Install the Core package in your new .NET MAUI Class Library project:

```bash
dotnet add package IgrisModz.MauiIcons.Core

```

### 2. Basic Setup (For End-Users)

If you are consuming a library built on Core, or initializing Core directly, add this to your `MauiProgram.cs` (usually handled automatically by the specific icon pack extensions):

```csharp
using MauiIcons.Core;

builder.UseMauiIconsCore();

```

---

## 🛠 How to create your own Icon Library

Here is a quick guide on how to use the Core to build your own icon controls.

### Example 1: Creating a Standard Static Icon Library

**Step 1:** Define your Enum mapped to the font glyphs.

```csharp
public enum MyCustomIcons
{
    Home = 0xe001,
    User = 0xe002,
    Settings = 0xe003
}

```

**Step 2:** Create the Icon Control by inheriting from the Core base class.

```csharp
using MauiIcons.Core;

public class MyCustomIcon : BaseIcon<MyCustomIcons>
{
}

```

**Step 3:** Create the Markup Extension for standard MAUI controls (Label, Button).

```csharp
using MauiIcons.Core;

public class MyCustomIconExtension : BaseIconExtension<MyCustomIcons>
{
}

```

---

### Example 2: Creating a Variable Font Icon Library

Variable Fonts allow dynamic changes to properties like `Weight`, `Fill`, or `Grade` without loading multiple font files.

**Step 1:** Define your Enum (same as above).

```csharp
public enum MyVariableIcons
{
    Search = 0xf100,
    Favorite = 0xf101
}

```

**Step 2:** Inherit from the Variable Base Control.
This base class exposes additional bindable properties specific to Variable Fonts.

```csharp
using MauiIcons.Core;

public class MyVariableIcon : VariableIconBase<MyVariableIcons>
{
}
```

*Note: Variable font axes like `Fill` and `Grade` are heavily platform-dependent and may not be fully supported on Windows (WinUI).*

---

### Step 3: Registration Extension

Finally, provide a handy extension method for your users to register your custom font in their `MauiProgram.cs`.

```csharp
using MauiIcons.Core.Helpers;

public static class MauiAppBuilderExtensions
{
    private const string FontFileName = "YourFontFileName.ttf";
    private const string FontFamilyName = "YourFontFamilyName";

    public static MauiAppBuilder UseMyCustomIcons(this MauiAppBuilder builder)
    {
        // Initializes Core engines
        builder.UseMauiIconsCore(); 

        // Register your font file (ensure it's an EmbeddedResource)
        builder.ConfigureFonts(fonts =>
        {
            FontRegistrationHelper.RegisterEmbeddedFont(
                fonts,
                typeof(BuilderExtensions).Assembly,
                FontFileName,
                FontFamilyName);
        });

        return builder;
    }
}

```

---

## 📄 License

This Core package is open-source and licensed under the **MIT License**. Feel free to use it to build commercial or open-source icon packs for the MAUI community!

---

*Maintained by IgrisModz. Part of the [MauiIcons Suite](https://github.com/IgrisModz/MauiIcons).*