.NET NAUI Icons - FontAwesome Solid

Getting Started

In order to use the .NET MAUI Icons - FontAwesome Solid library, you need to follow these steps:

In your `MauiProgram.cs`, add the following line to the `CreateMauiApp` method:

using MauiIcons.FontAwesome.Solid;


public static MauiApp CreateMauiApp()
{
	var builder = MauiApp.CreateBuilder();
	builder
		.UseMauiApp<App>()
		.UseFontAwesomeSolid(); // Add this line to register the FontAwesome Solid icons
	return builder.Build();
}


XAML Usage

In order to use the FontAwesome Solid icons in your XAML files, you need to add the following namespace declaration at the top of your XAML file:

xmlns:mi="http://www.igrismodz.com/dotnet/2026/maui/icons"


-------------------------------------------------------------------------------------------

Built-in Icons Usage

XAML:

<mi:FontAwesomeSolidIcon Icon="Bell" TextColor="Blue" FontSize="40" BackgroundColor="White" />

C#:

Using MauiIcons.FontAwesome.Solid;

var bellIcon = new FontAwesomeSolidIcon
{
	Icon = FontAwesomeSolidIcons.Bell,
	TextColor = Colors.Blue,
	FontSize = 40,
	BackgroundColor = Colors.White
};

--------------------------------------------------------------------------------------------

XAML Extension Usage:

<Label Text="{mi:FontAwesomeSolid Icon=Heart, Size=60, Color=DarkBlue}" />

<Button Text="{mi:FontAwesomeSolid Icon=House, Size=30, Color=SkyBlue}" />

<Image Source="{mi:FontAwesomeSolid Icon=Image, Size=50, Color=Black}" Aspect="Center" />

--------------------------------------------------------------------------------------------

XAML Animations:

// Animation don't work on all controls, like images, and buttons is full animated not only the icon.

<mi:FontAwesomeSolidIcon Icon="House" TextColor="Blue" FontSize="40" BackgroundColor="White" Animation="Shake" IsAnimationActive="True" />

<Label Text="{mi:FontAwesomeSolid Icon=Heart, Size=60, Color=DarkBlue, Animation=Spin, IsAnimationActive=True}" />

--------------------------------------------------------------------------------------------

XAML Binding:

// Icon, TextColor, FontSize, BackgroundColor, and Animation properties can be bound to your ViewModel properties. For example:

<mi:FontAwesomeSolidIcon Icon="{Binding SelectedIcon}" TextColor="{Binding YourIconColor}" FontSize="{Binding YourIconSize}" BackgroundColor="{Binding YourIconBackgroundColor}" Animation="{Binding YourIconAnimation}" IsAnimationActive="{Binding YourIconIsAnimated}" />

<Label Text="{mi:FontAwesomeSolid Icon={Binding SelectedIcon}, Size={Binding YourIconColor}, Color={Binding YourIconSize}, BackgroundColor="{Binding YourIconBackgroundColor}" Animation={Binding YourIconAnimation}, IsAnimationActive={Binding YourIconIsAnimated}}" />

--------------------------------------------------------------------------------------------

XAML Platform Extension Usage:

<mi:FontAwesomeSolidIcon Icon="{mi:FontAwesomeSolidPlatform WinUI=Heart}" FontSize="60" TextColor="Red" Animation="Rotate" IsAnimationActive="True"/>

<Label Text="{mi:FontAwesomeSolid Icon={mi:FontAwesomeSolidPlatform WinUI=House, Android=Heart, iOS=Image}, Size=60, Color=Orange}" VerticalOptions="Center" HorizontalOptions="Center"/>

<Label HorizontalOptions="Center" VerticalOptions="Center">
	<Label.Text>
		<mi:FontAwesomeSolid Size="60" Color="RosyBrown" Animation="Shake" IsAnimationActive="True">
			<mi:FontAwesomeSolid.Icon>
				<mi:FontAwesomeSolidPlatform WinUI="Newspaper" />
				<mi:FontAwesomeSolidPlatform Android="AddressCard" />
            </mi:FontAwesomeSolid.Icon>
        </mi:FontAwesomeSolid>
	</Label.Text>
</Label>

// You can also use this but the editor will currently it as an error

<mi:FontAwesomeSolidIcon>
	<mi:FontAwesomeSolidIcon.Icon>
		<mi:IconPlatform x:TypeArguments="mi:FontAwesomeSolidIcons" WinUI="AddressCard" />
	</mi:FontAwesomeSolidIcon.Icon>
</mi:FontAwesomeSolidIcon>

--------------------------------------------------------------------------------------------

You can also use the font-family directly in your XAML or C# code, but you need to make sure that the font (.UseFontAwesomeSolid()) is properly registered in your MauiProgram file:

<Label Text="&#xf02e;" FontSize="60" FontFamily="FontAwesomeSolidIcons" />



Disclaimer: It's important to note that the .NET MAUI Icons - FontAwesome Solid library is not affiliated with or endorsed by FontAwesome. The icons provided in this library are based on the FontAwesome Solid icon set, but they may not be an exact representation of the original icons. Please refer to the FontAwesome website for the official icons and licensing information.

PS: Not all controls support the icon extensions with all functions, such as animations, colors, and sizes. Please refer to the documentation for each control to see which features are supported.

---------------------------------------------------------------------------------------------

## Further Information

For more information and documentation, please visit the official GitHub repository of the .NET MAUI Icons - FontAwesome Solid library:

- GitHub Repository: https://github.com/IgrisModz/MauiIcons