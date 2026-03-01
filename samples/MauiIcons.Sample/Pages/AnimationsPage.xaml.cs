using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MauiIcons.Sample.Pages;

public partial class AnimationsPage : ContentPage, INotifyPropertyChanged
{
	private bool _enableRotate;

    public bool EnableRotate { get => _enableRotate; set => SetProperty(ref _enableRotate, value); }

    public Command RotateCommand { get; }

	public AnimationsPage()
	{
		RotateCommand = new Command(RotateYoutube);
		InitializeComponent();
		BindingContext = this;
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        EnableRotate = true;
    }

    protected bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName] string propertyName = "")
    {
        if (EqualityComparer<T>.Default.Equals(backingStore, value))
            return false;

        backingStore = value;
        OnPropertyChanged(propertyName);
        return true;
    }

    private void RotateYoutube()
    {
        EnableRotate = true;
    }
}
