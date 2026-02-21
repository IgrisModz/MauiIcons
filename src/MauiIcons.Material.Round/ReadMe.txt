.NET NAUI Icons - MaterialIcons Round

Getting Started

In order to use the .NET MAUI Icons - MaterialIcons Round library, you need to follow these steps:

In your `MauiProgram.cs`, add the following line to the `CreateMauiApp` method:

using MauiIcons.Material.Round;


public static MauiApp CreateMauiApp()
{
	var builder = MauiApp.CreateBuilder();
	builder
		.UseMauiApp<App>()
		.UseMaterialRound(); // Add this line to register the Material Round icons
	return builder.Build();
}


XAML Usage

In order to use the Material Round icons in your XAML files, you need to add the following namespace declaration at the top of your XAML file:

xmlns:mi="http://www.igrismodz.com/dotnet/2026/maui/icons"


-------------------------------------------------------------------------------------------

Built-in Icons Usage

XAML:

<mi:MaterialRoundIcon Icon="Search" TextColor="Blue" FontSize="40" BackgroundColor="White" />

C#:

Using MauiIcons.Material.Round;

var searchIcon = new MaterialRoundIcon
{
	Icon = MaterialRoundIcons.Search,
	TextColor = Colors.Blue,
	FontSize = 40,
	BackgroundColor = Colors.White
};

--------------------------------------------------------------------------------------------

XAML Extension Usage:

<Label Text="{mi:MaterialRound Icon=Favorite, Size=60, Color=DarkBlue}" />

<Button Text="{mi:MaterialRound Icon=Home, Size=30, Color=SkyBlue}" />

<Image Source="{mi:MaterialRound Icon=Imagee, Size=50, Color=Black}" Aspect="Center" />

--------------------------------------------------------------------------------------------

XAML Animations:

// Animation don't work on all controls, like images, and buttons is full animated not only the icon.

<mi:MaterialRoundIcon Icon="Home" TextColor="Blue" FontSize="40" BackgroundColor="White" Animation="Shake" IsAnimationActive="True" />

<Label Text="{mi:MaterialRound Icon=Favorite, Size=60, Color=DarkBlue, Animation=Spin, IsAnimationActive=True}" />

--------------------------------------------------------------------------------------------

XAML Binding:

// Icon, TextColor, FontSize, BackgroundColor, and Animation properties can be bound to your ViewModel properties. For example:

<mi:MaterialRoundIcon Icon="{Binding SelectedIcon}" TextColor="{Binding YourIconColor}" FontSize="{Binding YourIconSize}" BackgroundColor="{Binding YourIconBackgroundColor}" Animation="{Binding YourIconAnimation}" IsAnimationActive="{Binding YourIconIsAnimated}" />

<Label Text="{mi:MaterialRound Icon={Binding SelectedIcon}, Size={Binding YourIconColor}, Color={Binding YourIconSize}, BackgroundColor="{Binding YourIconBackgroundColor}" Animation={Binding YourIconAnimation}, IsAnimationActive={Binding YourIconIsAnimated}}" />

--------------------------------------------------------------------------------------------

XAML Platform Extension Usage:

<mi:MaterialRoundIcon Icon="{mi:MaterialRoundPlatform WinUI=Favorite}" FontSize="60" TextColor="Red" Animation="Rotate" IsAnimationActive="True"/>

<Label Text="{mi:MaterialRound Icon={mi:MaterialRoundPlatform WinUI=Home, Android=Favorite, iOS=Image}, Size=60, Color=Orange}" VerticalOptions="Center" HorizontalOptions="Center"/>

<Label HorizontalOptions="Center" VerticalOptions="Center">
	<Label.Text>
		<mi:MaterialRound Size="60" Color="RosyBrown" Animation="Shake" IsAnimationActive="True">
			<mi:MaterialRound.Icon>
				<mi:MaterialRoundPlatform WinUI="Logout" />
				<mi:MaterialRoundPlatform Android="Language" />
            </mi:MaterialRound.Icon>
        </mi:MaterialRound>
	</Label.Text>
</Label>

// You can also use this but the editor will currently it as an error

<mi:MaterialRoundIcon>
	<mi:MaterialRoundIcon.Icon>
		<mi:IconPlatform x:TypeArguments="mi:MaterialRoundIcons" WinUI="Verified" />
	</mi:MaterialRoundIcon.Icon>
</mi:MaterialRoundIcon>

--------------------------------------------------------------------------------------------

You can also use the font-family directly in your XAML or C# code, but you need to make sure that the font (.UseMaterialRound()) is properly registered in your MauiProgram file:

<Label Text="&#xef42;" FontSize="60" FontFamily="MaterialRoundIcons" />



Disclaimer: It's important to note that the .NET MAUI Icons - Material Round library is not affiliated with or endorsed by Material. The icons provided in this library are based on the Material Round icon set, but they may not be an exact representation of the original icons. Please refer to the Material website for the official icons and licensing information.

PS: Not all controls support the icon extensions with all functions, such as animations, colors, and sizes. Please refer to the documentation for each control to see which features are supported.

---------------------------------------------------------------------------------------------

## Further Information

For more information and documentation, please visit the official GitHub repository of the .NET MAUI Icons - Material Round library:

- GitHub Repository: https://github.com/IgrisModz/MauiIcons