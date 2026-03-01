
# IgrisModz.MauiIcons - MaterialSymbols.Rounded 🚀

[![NuGet](https://img.shields.io/nuget/v/IgrisModz.MauiIcons.MaterialSymbols.Rounded.svg)](https://www.nuget.org/packages/IgrisModz.MauiIcons.MaterialSymbols.Rounded/)
![.NET Version](https://img.shields.io/badge/.NET-10.0-purple.svg)

This library provides **Material Symbols Rounded** support for **.NET MAUI** (.NET 10). It utilizes **Variable Font** technology to offer highly customizable icons.

---

## ⚠️ Important Technical Constraints

### 1. Platform Support (Variable Axes)
Due to platform-specific rendering engines, support for variable axes varies:
* **Weight:** Supported on **all** platforms.
* **Fill, Grade, OpticalSize:** Supported on **Android & iOS**. These axes are currently **NOT supported on Windows (WinUI)**.

### 2. Control Compatibility
To ensure the icons render correctly with their variable properties:
* **Full Support:** Use the direct control `<mi:MaterialSymbolsRoundedIcon />`.
* **Container Support:** You can also use View-based controls like `ContentView`, `SwipeView`, etc.
* **Limited Support:** Standard text-based controls (like `Label` or `Button`) using Markup Extensions will only render the icon with default axes and **cannot** display advanced variable axes.

---

## 🚀 Getting Started

### 1. Installation
```bash
dotnet add package IgrisModz.MauiIcons.MaterialSymbols.Rounded
```

### 2. Configuration (MauiProgram.cs)

```csharp
builder.UseMaterialSymbolsRounded();
```

---

## 🛠 Usage

### Recommended: Direct Icon Control

This is the most reliable way to display icons with variable support:

```xml
<mi:MaterialSymbolsRoundedIcon Icon="Settings" 
                                TextColor="Blue" 
                                FontSize="40" 
                                Weight="700" 
                                Fill="True" />
```

### View-Based Controls
You can wrap icons in containers if needed:
```xml
<ContentView>
    <mi:MaterialSymbolsRoundedIcon Icon="Home" Weight="100" />
</ContentView>
```

---

## ✨ Features

* **Variable Font Support:** Adjust Weight (All platforms) and Fill/Grade/OpticalSize (Mobile only).
* **Typing Safety:** Full Enum support for all Material Symbols.
* **Animations:** Built-in support for `Spin`, `Shake`, `Pulse`, etc.
* **Binding:** Properties are fully bindable for MVVM scenarios.

---

## 📄 License & Disclaimer

Licensed under **MIT**.
**Disclaimer:** Not affiliated with Google. Please check [Material Symbols](https://fonts.google.com/icons) for original glyph licensing.

---

*Maintained by IgrisModz. Part of the [MauiIcons Suite](https://github.com/IgrisModz/MauiIcons).*