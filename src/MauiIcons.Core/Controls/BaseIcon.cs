using MauiIcons.Core.Extensions;
using System.ComponentModel;

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

	public static readonly BindableProperty IconProperty = BindableProperty.Create(nameof(Icon), typeof(TEnum), typeof(BaseIcon<TEnum>), default(TEnum), propertyChanged: OnIconChanged);
	public static readonly BindableProperty AnimationProperty = BindableProperty.Create(nameof(Animation), typeof(AnimationType), typeof(BaseIcon<TEnum>), AnimationType.None);
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



	[EditorBrowsable(EditorBrowsableState.Never)]
	public TEnum? IconSuggestions => default;

	public BaseIcon()
	{
		VerticalTextAlignment = TextAlignment.Center;
		HorizontalTextAlignment = TextAlignment.Center;
		FontSize = 30.0; // Default icon size
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

	public void StopAnimation()
	{
		animationSource?.Cancel();
		this.CancelAnimations();
		Rotation = 0;
		Scale = 1;
		TranslationX = 0;
	}

	protected virtual void Dispose(bool disposing)
	{
		if (disposing)
		{
			animationSource?.Cancel();
			animationSource?.Dispose();
		}
	}

	public void Dispose()
	{
		Dispose(true);
		GC.SuppressFinalize(this);
	}
}