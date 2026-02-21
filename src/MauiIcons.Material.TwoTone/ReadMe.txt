.NET NAUI Icons - MaterialIcons TwoTone

Getting Started

In order to use the .NET MAUI Icons - MaterialIcons TwoTone library, you need to follow these steps:

In your `MauiProgram.cs`, add the following line to the `CreateMauiApp` method:

using MauiIcons.Material.TwoTone;


public static MauiApp CreateMauiApp()
{
	var builder = MauiApp.CreateBuilder();
	builder
		.UseMauiApp<App>()
		.UseMaterialTwoTone(); // Add this line to register the Material TwoTone icons
	return builder.Build();
}


XAML Usage

In order to use the Material TwoTone icons in your XAML files, you need to add the following namespace declaration at the top of your XAML file:

xmlns:mi="http://www.igrismodz.com/dotnet/2026/maui/icons"


-------------------------------------------------------------------------------------------

Built-in Icons Usage

XAML:

<mi:MaterialTwoToneIcon Icon="Search" TextColor="Blue" FontSize="40" BackgroundColor="White" />

C#:

Using MauiIcons.Material.TwoTone;

var searchIcon = new MaterialTwoToneIcon
{
	Icon = MaterialTwoToneIcons.Search,
	TextColor = Colors.Blue,
	FontSize = 40,
	BackgroundColor = Colors.White
};

--------------------------------------------------------------------------------------------

XAML Extension Usage:

<Label Text="{mi:MaterialTwoTone Icon=Favorite, Size=60, Color=DarkBlue}" />

<Button Text="{mi:MaterialTwoTone Icon=Home, Size=30, Color=SkyBlue}" />

<Image Source="{mi:MaterialTwoTone Icon=Imagee, Size=50, Color=Black}" Aspect="Center" />

--------------------------------------------------------------------------------------------

XAML Animations:

// Animation don't work on all controls, like images, and buttons is full animated not only the icon.

<mi:MaterialTwoToneIcon Icon="Home" TextColor="Blue" FontSize="40" BackgroundColor="White" Animation="Shake" IsAnimationActive="True" />

<Label Text="{mi:MaterialTwoTone Icon=Favorite, Size=60, Color=DarkBlue, Animation=Spin, IsAnimationActive=True}" />

--------------------------------------------------------------------------------------------

XAML Binding:

// Icon, TextColor, FontSize, BackgroundColor, and Animation properties can be bound to your ViewModel properties. For example:

<mi:MaterialTwoToneIcon Icon="{Binding SelectedIcon}" TextColor="{Binding YourIconColor}" FontSize="{Binding YourIconSize}" BackgroundColor="{Binding YourIconBackgroundColor}" Animation="{Binding YourIconAnimation}" IsAnimationActive="{Binding YourIconIsAnimated}" />

<Label Text="{mi:MaterialTwoTone Icon={Binding SelectedIcon}, Size={Binding YourIconColor}, Color={Binding YourIconSize}, BackgroundColor="{Binding YourIconBackgroundColor}" Animation={Binding YourIconAnimation}, IsAnimationActive={Binding YourIconIsAnimated}}" />

--------------------------------------------------------------------------------------------

XAML Platform Extension Usage:

<mi:MaterialTwoToneIcon Icon="{mi:MaterialTwoTonePlatform WinUI=Favorite}" FontSize="60" TextColor="Red" Animation="Rotate" IsAnimationActive="True"/>

<Label Text="{mi:MaterialTwoTone Icon={mi:MaterialTwoTonePlatform WinUI=Home, Android=Favorite, iOS=Image}, Size=60, Color=Orange}" VerticalOptions="Center" HorizontalOptions="Center"/>

<Label HorizontalOptions="Center" VerticalOptions="Center">
	<Label.Text>
		<mi:MaterialTwoTone Size="60" Color="RosyBrown" Animation="Shake" IsAnimationActive="True">
			<mi:MaterialTwoTone.Icon>
				<mi:MaterialTwoTonePlatform WinUI="Logout" />
				<mi:MaterialTwoTonePlatform Android="Language" />
            </mi:MaterialTwoTone.Icon>
        </mi:MaterialTwoTone>
	</Label.Text>
</Label>

// You can also use this but the editor will currently it as an error

<mi:MaterialTwoToneIcon>
	<mi:MaterialTwoToneIcon.Icon>
		<mi:IconPlatform x:TypeArguments="mi:MaterialTwoToneIcons" WinUI="Verified" />
	</mi:MaterialTwoToneIcon.Icon>
</mi:MaterialTwoToneIcon>

--------------------------------------------------------------------------------------------

You can also use the font-family directly in your XAML or C# code, but you need to make sure that the font (.UseMaterialTwoTone()) is properly registered in your MauiProgram file:

<Label Text="&#xef42;" FontSize="60" FontFamily="MaterialTwoToneIcons" />



Disclaimer: It's important to note that the .NET MAUI Icons - Material TwoTone library is not affiliated with or endorsed by Material. The icons provided in this library are based on the Material TwoTone icon set, but they may not be an exact representation of the original icons. Please refer to the Material website for the official icons and licensing information.

PS: Not all controls support the icon extensions with all functions, such as animations, colors, and sizes. Please refer to the documentation for each control to see which features are supported.

---------------------------------------------------------------------------------------------

## Further Information

For more information and documentation, please visit the official GitHub repository of the .NET MAUI Icons - Material TwoTone library:

- GitHub Repository: https://github.com/IgrisModz/MauiIcons