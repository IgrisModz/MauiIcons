using MauiIcons.Core.Extensions;

namespace MauiIcons.Core.Controls;

/// <summary>
/// Provides a base class for icon controls that display a glyph from an enumeration and support configurable
/// animations.
/// </summary>
/// <remarks>This class is intended to be subclassed to create custom icon controls that use font-based glyphs. It
/// supports binding to an icon enumeration value and applying various animation effects, such as spinning or pulsing,
/// to the displayed icon. The animation behavior is controlled via the Animation and IsAnimationActive properties. The
/// class inherits from Label, allowing it to be used wherever a label is supported in the UI.</remarks>
/// <typeparam name="TEnum">The enumeration type that defines the available icons to display. Must be a value type that implements the Enum
/// constraint.</typeparam>
public abstract class BaseIcon<TEnum> : Label, IDisposable where TEnum : struct, Enum
{
	CancellationTokenSource? animationSource;

	/// <summary>
	/// Identifies the Icon bindable property for use with data binding and property change notifications.
	/// </summary>
	/// <remarks>This field is used to reference the Icon property in Xamarin.Forms or MAUI frameworks when
	/// implementing custom controls. It enables developers to bind and observe changes to the Icon property of a
	/// BaseIcon&lt;TEnum&gt; control.</remarks>
	public static readonly BindableProperty IconProperty = BindableProperty.Create(nameof(Icon), typeof(TEnum), typeof(BaseIcon<TEnum>), default(TEnum), propertyChanged: OnIconChanged);

	/// <summary>
	/// Identifies the Animation bindable property, which specifies the animation type applied to the icon.
	/// </summary>
	/// <remarks>Use this property to bind or set the animation type for the icon in XAML or code. The default value
	/// is AnimationType.None.</remarks>
	public static readonly BindableProperty AnimationProperty = BindableProperty.Create(nameof(Animation), typeof(AnimationType), typeof(BaseIcon<TEnum>), AnimationType.None);

	/// <summary>
	/// Identifies the bindable property that indicates whether the animation is active for the icon.
	/// </summary>
	/// <remarks>This property can be used to bind the animation state in data templates or view models. Changing
	/// its value triggers the associated property changed callback, which may start or stop the animation depending on the
	/// new value.</remarks>
	public static readonly BindableProperty IsAnimationActiveProperty = BindableProperty.Create(nameof(IsAnimationActive), typeof(bool), typeof(BaseIcon<TEnum>), false, propertyChanged: OnIsAnimationActiveChanged);

	/// <summary>
	/// Gets or sets the icon displayed by the control.
	/// </summary>
	public TEnum Icon { get => (TEnum)GetValue(IconProperty); set => SetValue(IconProperty, value); }

	/// <summary>
	/// Gets or sets the animation type applied to the control.
	/// </summary>
	/// <remarks>Use this property to specify how the control animates during transitions or state changes.
	/// The available animation types are defined by the AnimationType enumeration.</remarks>
	public AnimationType Animation { get => (AnimationType)GetValue(AnimationProperty); set => SetValue(AnimationProperty, value); }

	/// <summary>
	/// Gets or sets a value indicating whether the animation is currently active.
	/// </summary>
	public bool IsAnimationActive { get => (bool)GetValue(IsAnimationActiveProperty); set => SetValue(IsAnimationActiveProperty, value); }

    /// <summary>
	/// Initializes a new instance of the BaseIcon class with default alignment and font size settings.
	/// </summary>
	/// <remarks>The constructor sets the vertical and horizontal text alignment to center and assigns a default
	/// font size of 30.0. It also initializes the icon display based on the current Icon property value.</remarks>
	public BaseIcon()
	{
		VerticalTextAlignment = TextAlignment.Center;
		HorizontalTextAlignment = TextAlignment.Center;
		FontSize = 30.0;
		UpdateIcon(Icon);
	}

	static void OnIconChanged(BindableObject bindable, object oldValue, object newValue)
	{
		if (bindable is BaseIcon<TEnum> control && newValue is TEnum iconEnum)
		{
			control.UpdateIcon(iconEnum);
		}
	}

	void UpdateIcon(TEnum iconEnum)
	{
		FontFamily = iconEnum.GetFontFamily();
		Text = iconEnum.GetGlyph();
	}

	static void OnIsAnimationActiveChanged(BindableObject bindable, object oldValue, object newValue)
	{
		if (bindable is BaseIcon<TEnum> control)
		{
			if ((bool)newValue)
			{
				control.StartAnimation();
			}
			else
			{
				control.StopAnimation();
			}
		}
	}

	async void StartAnimation()
	{
		StopAnimation(); // Security

		animationSource?.Dispose();
		animationSource = new CancellationTokenSource();
		var token = animationSource.Token;

		try
		{
			switch (Animation)
			{
				case AnimationType.Spin:
					while (!token.IsCancellationRequested)
					{
						await this.RelRotateToAsync(360, 2000, Easing.Linear);
						Rotation = 0;
					}
					break;

				case AnimationType.Pulse:
					while (!token.IsCancellationRequested)
					{
						await this.ScaleToAsync(1.2, 500, Easing.CubicIn);
						await this.ScaleToAsync(1.0, 500, Easing.CubicOut);
					}
					break;
				case AnimationType.Rotate:
					// Simple rotation (One-shot)
					await this.RotateToAsync(360, 500, Easing.CubicInOut);
					Rotation = 0;
					IsAnimationActive = false; // Auto reset
					break;
				case AnimationType.Shake:
					while (!token.IsCancellationRequested)
					{
						await this.TranslateToAsync(-5, 0, 50);
						await this.TranslateToAsync(5, 0, 50);
						TranslationX = 0;
						await Task.Delay(100, token);
					}
					break;
			}
		}
		catch (Exception) { }
	}

	/// <summary>
	/// Stops any ongoing animation and resets the object's transformation properties to their default values.
	/// </summary>
	/// <remarks>Calling this method cancels all current animations and restores the object's rotation, scale, and
	/// translation to their initial states. This method is safe to call even if no animation is currently
	/// running.</remarks>
	public void StopAnimation()
	{
		animationSource?.Cancel();
		this.CancelAnimations();
		Rotation = 0;
		Scale = 1;
		TranslationX = 0;
	}

	/// <summary>
	/// Libère les ressources utilisées par l'objet en cours, en option libérant les ressources managées et non managées.
	/// </summary>
	/// <remarks>Cette méthode est appelée par la méthode Dispose et le finaliseur, le cas échéant. Lorsqu'elle est
	/// appelée avec disposing défini sur true, cette méthode libère toutes les ressources détenues par les objets managés
	/// référencés par ce composant. Remplacez cette méthode pour libérer des ressources spécifiques à la classe
	/// dérivée.</remarks>
	/// <param name="disposing">true pour libérer à la fois les ressources managées et non managées ; false pour libérer uniquement les ressources
	/// non managées.</param>
	protected virtual void Dispose(bool disposing)
	{
		if (disposing)
		{
			animationSource?.Cancel();
			animationSource?.Dispose();
		}
	}

	/// <summary>
	/// Releases all resources used by the current instance of the class.
	/// </summary>
	/// <remarks>Call this method when you are finished using the object to free unmanaged resources and perform
	/// other cleanup operations. After calling this method, the object should not be used further. This method suppresses
	/// finalization for the object.</remarks>
	public void Dispose()
	{
		Dispose(true);
		GC.SuppressFinalize(this);
	}
}