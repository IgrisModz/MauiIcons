*******************************************************************************************
.NET MAUI Icons - Material Round
*******************************************************************************************

Thank you for installing IgrisModz.MauiIcons.Material.Round!
This library provides a seamless way to use Google Material Round icons in .NET 10 MAUI.

===========================================================================================
1. GETTING STARTED
===========================================================================================

In your `MauiProgram.cs`, register the library by adding the following:

using MauiIcons.Material.Round;

public static MauiApp CreateMauiApp()
{
    var builder = MauiApp.CreateBuilder();
    builder
        .UseMauiApp<App>()
        .UseMaterialRound(); // Essential for font registration

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
<mi:MaterialRoundIcon Icon="Search" TextColor="Blue" FontSize="40" />

C#:
using MauiIcons.Material.Round;

var searchIcon = new MaterialRoundIcon
{
    Icon = MaterialRoundIcons.Search,
    TextColor = Colors.Blue,
    FontSize = 40
};

-------------------------------------------------------------------------------------------
B. Markup Extensions (Label, Button, Image)
-------------------------------------------------------------------------------------------

<Label Text="{mi:MaterialRound Icon=Favorite, Size=60, Color=DarkBlue}" />

<Button Text="{mi:MaterialRound Icon=Home, Size=30, Color=SkyBlue}" />

<Image Source="{mi:MaterialRound Icon=Settings, Size=50, Color=Black}" Aspect="Center" />

-------------------------------------------------------------------------------------------
C. Animations
-------------------------------------------------------------------------------------------

NOTE: Animations do not work on all controls. Buttons animate the entire control.

<mi:MaterialRoundIcon Icon="Home" Animation="Shake" IsAnimationActive="True" />

<Label Text="{mi:MaterialRound Icon=Favorite, Animation=Spin, IsAnimationActive=True}" />

-------------------------------------------------------------------------------------------
D. Platform-Specific Icons
-------------------------------------------------------------------------------------------

<mi:MaterialRoundIcon Icon="{mi:MaterialRoundPlatform WinUI=Favorite, Android=Home}" 
                         FontSize="60" />

<Label Text="{mi:MaterialRound Icon={mi:MaterialRoundPlatform WinUI=Logout, Android=Language}}" />

===========================================================================================
3. DATA BINDING
===========================================================================================

Icon, TextColor, FontSize, and Animation properties are Bindable:

<mi:MaterialRoundIcon Icon="{Binding SelectedIcon}" 
                         TextColor="{Binding IconColor}" 
                         Animation="{Binding MyAnimation}" />

===========================================================================================
4. MANUAL USAGE (Advanced)
===========================================================================================

If you prefer using Glyph codes and FontFamily directly (ensure UseMaterialRound is called):

<Label Text="&#xef42;" FontSize="60" FontFamily="MaterialRound" />

===========================================================================================
DISCLAIMER & NOTES
===========================================================================================

* This library is not affiliated with or endorsed by Google. 
* Material Round icons are based on the Material Icons set (v4.0.0).
* Not all MAUI controls support advanced extension features (animations/specific sizing).

-------------------------------------------------------------------------------------------
FURTHER INFORMATION
-------------------------------------------------------------------------------------------

For full documentation and community support, please visit the GitHub repository:
https://github.com/IgrisModz/MauiIcons

Happy Coding!
*******************************************************************************************