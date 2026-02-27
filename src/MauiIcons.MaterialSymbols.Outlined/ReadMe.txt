*******************************************************************************************
.NET MAUI Icons - Material Symbols Outlined
*******************************************************************************************

Thank you for installing IgrisModz.MauiIcons.MaterialSymbols.Outlined!
This library provides a seamless way to use Google Material Symbols Outlined icons in .NET 10 MAUI.

===========================================================================================
1. GETTING STARTED
===========================================================================================

In your `MauiProgram.cs`, register the library by adding the following:

using MauiIcons.MaterialSymbols.Outlined;

public static MauiApp CreateMauiApp()
{
    var builder = MauiApp.CreateBuilder();
    builder
        .UseMauiApp<App>()
        .UseMaterialSymbolsOutlined(); // Essential for font registration

    return builder.Build();
}

===========================================================================================
2. XAML USAGE
===========================================================================================

Add this unique namespace declaration at the top of your XAML file:

xmlns:mi="http://www.igrismodz.com/dotnet/2026/maui/icons"

-------------------------------------------------------------------------------------------
A. Built-in Icon Controls
-------------------------------------------------------------------------------------------

XAML:
<mi:MaterialSymbolsOutlinedIcon Icon="Search" TextColor="Blue" FontSize="40" />

C#:
using MauiIcons.MaterialSymbols.Outlined;

var searchIcon = new MaterialSymbolsOutlinedIcon
{
    Icon = MaterialSymbolsOutlinedIcons.Search,
    TextColor = Colors.Blue,
    FontSize = 40
};

-------------------------------------------------------------------------------------------
B. Markup Extensions (Label, Button, Image)
-------------------------------------------------------------------------------------------

<Label Text="{mi:MaterialSymbolsOutlined Icon=Favorite, Size=60, Color=DarkBlue}" />

<Button Text="{mi:MaterialSymbolsOutlined Icon=Home, Size=30, Color=SkyBlue}" />

<Image Source="{mi:MaterialSymbolsOutlined Icon=Settings, Size=50, Color=Black}" Aspect="Center" />

-------------------------------------------------------------------------------------------
C. Animations
-------------------------------------------------------------------------------------------

NOTE: Animations do not work on all controls. Buttons animate the entire control.

<mi:MaterialSymbolsOutlinedIcon Icon="Home" Animation="Shake" IsAnimationActive="True" />

<Label Text="{mi:MaterialSymbolsOutlined Icon=Favorite, Animation=Spin, IsAnimationActive=True}" />

-------------------------------------------------------------------------------------------
D. Platform-Specific Icons
-------------------------------------------------------------------------------------------

<mi:MaterialSymbolsOutlinedIcon Icon="{mi:MaterialSymbolsOutlinedPlatform WinUI=Favorite, Android=Home}" 
                         FontSize="60" />

<Label Text="{mi:MaterialSymbolsOutlined Icon={mi:MaterialSymbolsOutlinedPlatform WinUI=Logout, Android=Language}}" />

===========================================================================================
3. DATA BINDING
===========================================================================================

Icon, TextColor, FontSize, and Animation properties are Bindable:

<mi:MaterialSymbolsOutlinedIcon Icon="{Binding SelectedIcon}" 
                         TextColor="{Binding IconColor}" 
                         Animation="{Binding MyAnimation}" />

===========================================================================================
4. MANUAL USAGE (Advanced)
===========================================================================================

If you prefer using Glyph codes and FontFamily directly (ensure UseMaterialSymbolsOutlined is called):

<Label Text="&#xef42;" FontSize="60" FontFamily="MaterialSymbolsOutlined" />

===========================================================================================
DISCLAIMER & NOTES
===========================================================================================

* This library is not affiliated with or endorsed by Google. 
* Material Symbols Outlined icons are based on the Material Symbols.
* Not all MAUI controls support advanced extension features (animations/specific sizing).

-------------------------------------------------------------------------------------------
FURTHER INFORMATION
-------------------------------------------------------------------------------------------

For full documentation and community support, please visit the GitHub repository:
https://github.com/IgrisModz/MauiIcons

Happy Coding!
*******************************************************************************************