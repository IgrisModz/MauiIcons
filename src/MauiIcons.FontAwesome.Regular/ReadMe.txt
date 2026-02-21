.NET NAUI Icons - FontAwesome Regular

Getting Started

In order to use the .NET MAUI Icons - FontAwesome Regular library, you need to follow these steps:

In your `MauiProgram.cs`, add the following line to the `CreateMauiApp` method:

using MauiIcons.FontAwesome.Regular;


public static MauiApp CreateMauiApp()
{
	var builder = MauiApp.CreateBuilder();
	builder
		.UseMauiApp<App>()
		.UseFontAwesomeRegular(); // Add this line to register the FontAwesome Regular icons
	return builder.Build();
}


XAML Usage

In order to use the FontAwesome Regular icons in your XAML files, you need to add the following namespace declaration at the top of your XAML file:

xmlns:mi="http://www.igrismodz.com/dotnet/2026/maui/icons"


-------------------------------------------------------------------------------------------

Built-in Icons Usage

XAML:

<mi:FontAwesomeRegularIcon Icon="Bell" TextColor="Blue" FontSize="40" BackgroundColor="White" />

C#:

Using MauiIcons.FontAwesome.Regular;

var bellIcon = new FontAwesomeRegularIcon
{
	Icon = FontAwesomeRegularIcons.Bell,
	TextColor = Colors.Blue,
	FontSize = 40,
	BackgroundColor = Colors.White
};

--------------------------------------------------------------------------------------------

XAML Extension Usage:

<Label Text="{mi:FontAwesomeRegular Icon=Heart, Size=60, Color=DarkBlue}" />

<Button Text="{mi:FontAwesomeRegular Icon=House, Size=30, Color=SkyBlue}" />

<Image Source="{mi:FontAwesomeRegular Icon=Image, Size=50, Color=Black}" Aspect="Center" />

--------------------------------------------------------------------------------------------

XAML Animations:

// Animation don't work on all controls, like images, and buttons is full animated not only the icon.

<mi:FontAwesomeRegularIcon Icon="House" TextColor="Blue" FontSize="40" BackgroundColor="White" Animation="Shake" IsAnimationActive="True" />

<Label Text="{mi:FontAwesomeRegular Icon=Heart, Size=60, Color=DarkBlue, Animation=Spin, IsAnimationActive=True}" />

--------------------------------------------------------------------------------------------

XAML Binding:

// Icon, TextColor, FontSize, BackgroundColor, and Animation properties can be bound to your ViewModel properties. For example:

<mi:FontAwesomeRegularIcon Icon="{Binding SelectedIcon}" TextColor="{Binding YourIconColor}" FontSize="{Binding YourIconSize}" BackgroundColor="{Binding YourIconBackgroundColor}" Animation="{Binding YourIconAnimation}" IsAnimationActive="{Binding YourIconIsAnimated}" />

<Label Text="{mi:FontAwesomeRegular Icon={Binding SelectedIcon}, Size={Binding YourIconColor}, Color={Binding YourIconSize}, BackgroundColor="{Binding YourIconBackgroundColor}" Animation={Binding YourIconAnimation}, IsAnimationActive={Binding YourIconIsAnimated}}" />

--------------------------------------------------------------------------------------------

XAML Platform Extension Usage:

<mi:FontAwesomeRegularIcon Icon="{mi:FontAwesomeRegularPlatform WinUI=Heart}" FontSize="60" TextColor="Red" Animation="Rotate" IsAnimationActive="True"/>

<Label Text="{mi:FontAwesomeRegular Icon={mi:FontAwesomeRegularPlatform WinUI=House, Android=Heart, iOS=Image}, Size=60, Color=Orange}" VerticalOptions="Center" HorizontalOptions="Center"/>

<Label HorizontalOptions="Center" VerticalOptions="Center">
	<Label.Text>
		<mi:FontAwesomeRegular Size="60" Color="RosyBrown" Animation="Shake" IsAnimationActive="True">
			<mi:FontAwesomeRegular.Icon>
				<mi:FontAwesomeRegularPlatform WinUI="Newspaper" />
				<mi:FontAwesomeRegularPlatform Android="AddressCard" />
            </mi:FontAwesomeRegular.Icon>
        </mi:FontAwesomeRegular>
	</Label.Text>
</Label>

// You can also use this but the editor will currently it as an error

<mi:FontAwesomeRegularIcon>
	<mi:FontAwesomeRegularIcon.Icon>
		<mi:IconPlatform x:TypeArguments="mi:FontAwesomeRegularIcons" WinUI="AddressCard" />
	</mi:FontAwesomeRegularIcon.Icon>
</mi:FontAwesomeRegularIcon>

--------------------------------------------------------------------------------------------

You can also use the font-family directly in your XAML or C# code, but you need to make sure that the font (.UseFontAwesomeRegular()) is properly registered in your MauiProgram file:

<Label Text="&#xf02e;" FontSize="60" FontFamily="FontAwesomeRegularIcons" />



Disclaimer: It's important to note that the .NET MAUI Icons - FontAwesome Regular library is not affiliated with or endorsed by FontAwesome. The icons provided in this library are based on the FontAwesome Regular icon set, but they may not be an exact representation of the original icons. Please refer to the FontAwesome website for the official icons and licensing information.

PS: Not all controls support the icon extensions with all functions, such as animations, colors, and sizes. Please refer to the documentation for each control to see which features are supported.

---------------------------------------------------------------------------------------------

## Further Information

For more information and documentation, please visit the official GitHub repository of the .NET MAUI Icons - FontAwesome Regular library:

- GitHub Repository: https://github.com/IgrisModz/MauiIcons