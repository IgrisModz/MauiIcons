*******************************************************************************************
.NET MAUI Icons - Material Symbols Outlined (Variable Font)
*******************************************************************************************

IMPORTANT: PLEASE READ TECHNICAL CONSTRAINTS BELOW

This library uses Variable Font technology which has specific platform behaviors:

1. PLATFORM AXES SUPPORT:
   - Weight: Works on ALL platforms.
   - Fill, Grade, OpticalSize: Works on Android/iOS ONLY (Not supported on Windows).

2. RECOMMENDED CONTROLS:
   - Use the direct control: <mi:MaterialSymbolsOutlinedIcon />
   - Or View-based controls: ContentView, SwipeView, etc.
   - Standard Labels/Buttons using extensions DO NOT support variable axes.

===========================================================================================
GETTING STARTED
===========================================================================================

In MauiProgram.cs:
.UseMaterialSymbolsOutlined();

XAML Namespace:
xmlns:mi="http://www.igrismodz.com/dotnet/2026/maui/icons"

===========================================================================================
USAGE EXAMPLES
===========================================================================================

Direct Control (Best for all features):
<mi:MaterialSymbolsOutlinedIcon Icon="Search" 
                                Weight="700" 
                                Fill="True" /> 

Markup Extension (Limited to default style):
<Label Text="{mi:MaterialSymbolsOutlined Icon=Favorite}" />

===========================================================================================
NOTES
===========================================================================================
* Animations (Spin, Shake, etc.) are fully supported on the Icon Control.
* All icon properties are Bindable for MVVM.
* This library is not affiliated with Google.

GitHub: https://github.com/IgrisModz/MauiIcons
*******************************************************************************************