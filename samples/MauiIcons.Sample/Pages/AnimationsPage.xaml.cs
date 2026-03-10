using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MauiIcons.Sample.Pages;

public partial class AnimationsPage : ContentPage, INotifyPropertyChanged
{
	bool enableRotate;

	public bool EnableRotate { get => enableRotate; set => SetProperty(ref enableRotate, value); }

	public Command RotateCommand { get; }

	public AnimationsPage()
	{
		RotateCommand = new Command(RotateYoutube);
		InitializeComponent();
		BindingContext = this;
	}

	void Button_Clicked(object? sender, EventArgs e)
	{
		EnableRotate = true;
	}

	protected bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName] string? propertyName = null)
	{
		if (EqualityComparer<T>.Default.Equals(backingStore, value))
		{
			return false;
		}

		backingStore = value;
		OnPropertyChanged(propertyName);
		return true;
	}

	void RotateYoutube()
	{
		EnableRotate = true;
	}
}
