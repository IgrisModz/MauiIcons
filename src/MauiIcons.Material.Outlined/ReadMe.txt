*******************************************************************************************
.NET MAUI Icons - Material Outlined
*******************************************************************************************

Thank you for installing IgrisModz.MauiIcons.Material.Outlined!
This library provides a seamless way to use Google Material Outlined icons in .NET 10 MAUI.

===========================================================================================
1. GETTING STARTED
===========================================================================================

In your `MauiProgram.cs`, register the library by adding the following:

using MauiIcons.Material.Outlined;

public static MauiApp CreateMauiApp()
{
    var builder = MauiApp.CreateBuilder();
    builder
        .UseMauiApp<App>()
        .UseMaterialOutlined(); // Essential for font registration

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
<mi:MaterialOutlinedIcon Icon="Search" TextColor="Blue" FontSize="40" />

C#:
using MauiIcons.Material.Outlined;

var searchIcon = new MaterialOutlinedIcon
{
    Icon = MaterialOutlinedIcons.Search,
    TextColor = Colors.Blue,
    FontSize = 40
};

-------------------------------------------------------------------------------------------
B. Markup Extensions (Label, Button, Image)
-------------------------------------------------------------------------------------------

<Label Text="{mi:MaterialOutlined Icon=Favorite, Size=60, Color=DarkBlue}" />

<Button Text="{mi:MaterialOutlined Icon=Home, Size=30, Color=SkyBlue}" />

<Image Source="{mi:MaterialOutlined Icon=Settings, Size=50, Color=Black}" Aspect="Center" />

-------------------------------------------------------------------------------------------
C. Animations
-------------------------------------------------------------------------------------------

NOTE: Animations do not work on all controls. Buttons animate the entire control.

<mi:MaterialOutlinedIcon Icon="Home" Animation="Shake" IsAnimationActive="True" />

<Label Text="{mi:MaterialOutlined Icon=Favorite, Animation=Spin, IsAnimationActive=True}" />

-------------------------------------------------------------------------------------------
D. Platform-Specific Icons
-------------------------------------------------------------------------------------------

<mi:MaterialOutlinedIcon Icon="{mi:MaterialOutlinedPlatform WinUI=Favorite, Android=Home}" 
                         FontSize="60" />

<Label Text="{mi:MaterialOutlined Icon={mi:MaterialOutlinedPlatform WinUI=Logout, Android=Language}}" />

===========================================================================================
3. DATA BINDING
===========================================================================================

Icon, TextColor, FontSize, and Animation properties are Bindable:

<mi:MaterialOutlinedIcon Icon="{Binding SelectedIcon}" 
                         TextColor="{Binding IconColor}" 
                         Animation="{Binding MyAnimation}" />

===========================================================================================
4. MANUAL USAGE (Advanced)
===========================================================================================

If you prefer using Glyph codes and FontFamily directly (ensure UseMaterialOutlined is called):

<Label Text="&#xef42;" FontSize="60" FontFamily="MaterialOutlined" />

===========================================================================================
DISCLAIMER & NOTES
===========================================================================================

* This library is not affiliated with or endorsed by Google. 
* Material Outlined icons are based on the Material Icons set (v4.0.0).
* Not all MAUI controls support advanced extension features (animations/specific sizing).

-------------------------------------------------------------------------------------------
FURTHER INFORMATION
-------------------------------------------------------------------------------------------

For full documentation and community support, please visit the GitHub repository:
https://github.com/IgrisModz/MauiIcons

Happy Coding!
*******************************************************************************************