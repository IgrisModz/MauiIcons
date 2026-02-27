
# IgrisModz.MauiIcons - MaterialSymbols.Sharp 🚀

[![NuGet](https://img.shields.io/nuget/v/IgrisModz.MauiIcons.MaterialSymbols.Sharp.svg)](https://www.nuget.org/packages/IgrisModz.MauiIcons.MaterialSymbols.Sharp/)
![.NET Version](https://img.shields.io/badge/.NET-10.0-purple.svg)

This library provides **MaterialSymbols Sharp** support for **.NET MAUI** (.NET 10). It allows you to use icons as fonts, offering full control over size, color, and animations with high performance.

---

## 🚀 Getting Started

### 1. Installation
Install the package via NuGet:

```bash
dotnet add package IgrisModz.MauiIcons.MaterialSymbols.Sharp
```

### 2. Configuration

In your `MauiProgram.cs`, call the registration method to ensure the fonts are correctly loaded:

```csharp
using MauiIcons.MaterialSymbols.Sharp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMaterialSymbolsSharp();

        return builder.Build();
    }
}
```

---

## 🛠 Usage

### XAML Namespace

Add the following unique namespace to your XAML file:

```xml
xmlns:mi="http://www.igrismodz.com/dotnet/2026/maui/icons"
```

### Built-in Control

Use the dedicated icon control for full feature support:

```xml
<mi:MaterialSymbolsSharpIcon Icon="Heart" 
                         TextColor="Red" 
                         FontSize="40" 
                         Animation="Pulse" 
                         IsAnimationActive="True" />
```

### XAML Extensions

Apply icons directly to any standard control (Label, Button, Image, etc.):

```xml
<Label Text="{mi:MaterialSymbolsSharp Icon=Home, Size=60, Color=DarkBlue}" />
<Image Source="{mi:MaterialSymbolsSharp Icon=Image, Size=50}" />
```

### Platform-Specific Icons

```xml
<mi:MaterialSymbolsSharpIcon Icon="{mi:MaterialSymbolsSharpPlatform WinUI=Image, Android=Home}" />
```

---

## ✨ Features

* **Typing Safety:** Use Enums in C# to avoid magic strings.
* **Markup Extensions:** Seamless integration with standard MAUI controls.
* **Animations:** Built-in support for `Spin`, `Shake`, `Rotate`, and more.
* **Binding:** Fully compatible with MVVM and Data Binding.

---

## 📄 License & Disclaimer

This project is licensed under the **MIT License**.

**Disclaimer:** This library is not affiliated with or endorsed by the original icon creators (Google). Please refer to the official icon providers for their specific licensing terms.

---

*Maintained by IgrisModz. Part of the [MauiIcons Suite](https://github.com/IgrisModz/MauiIcons).*