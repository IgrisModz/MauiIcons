using MauiIcons.Core.Controls;
using MauiIcons.Core.Converters;
using System.Reflection;

namespace MauiIcons.Core.Extensions;

/// <summary>
/// Représente une extension de balisage générique permettant de fournir dynamiquement des icônes, issues d'une
/// énumération, dans les interfaces utilisateur XAML. Permet la configuration de l'icône, de sa couleur, de sa taille,
/// de son animation et de son apparence via des propriétés liées.
/// </summary>
/// <remarks>Utilisez cette extension dans XAML pour injecter des icônes personnalisées dans des propriétés telles
/// que Image.Source, ContentView.Content ou Label.Text. Les propriétés exposées permettent de contrôler l'apparence et
/// le comportement de l'icône, y compris la couleur, la taille, l'animation et le fond. L'extension adapte
/// automatiquement la valeur retournée au type attendu par la propriété cible (ImageSource, View ou chaîne de
/// caractères). Elle prend en charge les scénarios MVVM grâce à la liaison de données et peut appliquer des animations
/// prédéfinies selon la configuration. Cette classe est conçue pour être utilisée avec .NET MAUI ou
/// Xamarin.Forms.</remarks>
/// <typeparam name="TEnum">Le type d'énumération utilisé pour sélectionner l'icône à afficher. Doit être une énumération (Enum) structurelle.</typeparam>
[ContentProperty(nameof(Icon))]
public partial class IconExtension<TEnum> : BindableObject, IMarkupExtension<object> where TEnum : struct, Enum
{
	WeakReference<VisualElement>? targetReference;

	/// <summary>
	/// Defines a bindable property for the icon enumeration value. This property allows you to specify which icon to display
	/// </summary>
	public static readonly BindableProperty IconProperty = BindableProperty.Create(nameof(Icon), typeof(TEnum), typeof(IconExtension<TEnum>), default(TEnum));

	/// <summary>
	/// Defines a bindable property for the color of the icon. This property allows you to set the color of the icon when it is rendered.
	/// </summary>
	public static readonly BindableProperty ColorProperty = BindableProperty.Create(nameof(Color), typeof(Color), typeof(IconExtension<TEnum>), null);

	/// <summary>
	/// Defines a bindable property for the background color of the icon. This property allows you to set the background color behind the icon when it is rendered.
	/// </summary>
	public static readonly BindableProperty BackgroundColorProperty = BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(IconExtension<TEnum>), null);

	/// <summary>
	/// Defines a bindable property for the size of the icon. This property allows you to specify the size (e.g., font size) at which the icon should be rendered. The default value is 30.0.
	/// </summary>
	public static readonly BindableProperty SizeProperty = BindableProperty.Create(nameof(Size), typeof(double), typeof(IconExtension<TEnum>), 30.0);

	/// <summary>
	/// Defines a bindable property for the animation type applied to the control. This property allows you to specify the type of animation (e.g., rotation, pulse) that should be applied to the icon when it is rendered or when certain state changes occur. The default value is AnimationType.None, indicating that no animation will be applied unless explicitly set.
	/// </summary>
	public static readonly BindableProperty AnimationProperty = BindableProperty.Create(nameof(Animation), typeof(AnimationType), typeof(IconExtension<TEnum>), AnimationType.None);

	/// <summary>
	/// Defines a bindable property that indicates whether the animation is currently active. This property allows you to control the activation of the specified animation. When set to true, the animation defined by the Animation property will be triggered; when set to false, any active animation will be stopped. The default value is false, meaning that animations will not be active unless explicitly enabled. Changes to this property will trigger an update to the animation state of the target control through the OnIsAnimationActivePropertyChanged callback.
	/// </summary>
	public static readonly BindableProperty IsAnimationActiveProperty = BindableProperty.Create(nameof(IsAnimationActive), typeof(bool), typeof(BaseIcon<TEnum>), false, propertyChanged: OnIsAnimationActivePropertyChanged);

	/// <summary>
	/// Gets or sets the icon to display for this control.
	/// </summary>
	/// <remarks>The value must be a valid member of the generic enumeration type <typeparamref
	/// name="TEnum"/>. Changing this property updates the visual representation of the control to reflect the selected
	/// icon.</remarks>
	public TEnum Icon { get => (TEnum)GetValue(IconProperty); set => SetValue(IconProperty, value); }

	/// <summary>
	/// Gets or sets the color associated with this element.
	/// </summary>
	public Color Color { get => (Color)GetValue(ColorProperty); set => SetValue(ColorProperty, value); }

	/// <summary>
	/// Gets or sets the background color associated with this element.
	/// </summary>
	public Color BackgroundColor { get => (Color)GetValue(BackgroundColorProperty); set => SetValue(BackgroundColorProperty, value); }

	/// <summary>
	/// Gets or sets the size value associated with the element.
	/// </summary>
	public double Size { get => (double)GetValue(SizeProperty); set => SetValue(SizeProperty, value); }

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
	/// Gets the name of the font family used to render the icon.
	/// </summary>
	public string FontFamily => Icon.GetFontFamily();

	/// <summary>
	/// Gets the Unicode glyph character associated with the icon.
	/// </summary>
	public string Glyph => Icon.GetGlyph();

	/// <summary>
	/// Provides a value for the target property based on the context supplied by the specified service provider. This
	/// method is typically used in XAML markup extensions to supply values at runtime.
	/// </summary>
	/// <remarks>The returned value adapts to the type expected by the target property, such as an
	/// ImageSource, a View, or a string. If the target object is an image, additional properties such as aspect and
	/// size may be set. Styles and animation handlers may also be applied to certain target objects. This method is
	/// commonly used in custom markup extensions for Xamarin.Forms or .NET MAUI.</remarks>
	/// <param name="serviceProvider">An object that can provide services for the markup extension. Must not be null.</param>
	/// <returns>The value to set on the target property. The returned type depends on the expected property type: an image
	/// source, a view, or a glyph string. Returns an empty string if the target property cannot be determined.</returns>
	public object ProvideValue(IServiceProvider serviceProvider)
	{
		var provideValueTarget = serviceProvider.GetService<IProvideValueTarget>();
		if (provideValueTarget == null)
		{
			return string.Empty;
		}

		// Detection of the expected return type (BindingProperty or classic PropertyInfo)
		var targetPropertyType = (provideValueTarget.TargetProperty as BindableProperty)?.ReturnType
								  ?? (provideValueTarget.TargetProperty as PropertyInfo)?.PropertyType;

		var targetObject = provideValueTarget.TargetObject;

		// The target expects an ImageSource (e.g., Image.Source, ToolbarItem.Icon)
		if (targetPropertyType == typeof(ImageSource) || targetPropertyType == typeof(FontImageSource))
		{
			if (targetObject is Image img)
			{
				img.Aspect = Aspect.Center;
				if (Size > 0) { img.HeightRequest = Size; img.WidthRequest = Size; }
			}
			return CreateImageSource();
		}

		// The target expects a VIEW (e.g., ContentView.Content, Frame.Content)
		if (targetPropertyType == typeof(View) || targetPropertyType == typeof(IView))
		{
			return CreateBaseIconControl();
		}

		// Control management (Label, Button, etc.)
		if (targetObject is BindableObject bindableTarget)
		{
			ApplyStyles(bindableTarget);

			if (bindableTarget is VisualElement visualTarget)
			{
				AttachAnimationHandler(visualTarget);
			}
		}

		return Glyph;
	}

	/// <summary>
	/// Creates and configures the base icon control with bindings to the relevant properties.
	/// </summary>
	/// <remarks>The returned control is set up for data binding to support MVVM scenarios. Override this method to
	/// customize the icon control's appearance or behavior in derived classes.</remarks>
	/// <returns>A configured instance of the icon control with property bindings applied.</returns>
	protected virtual View CreateBaseIconControl()
	{
		// We instantiate our concrete internal class
		var iconControl = new GenericIcon();

		// The extension is linked to the control for bidirectional responsiveness.
		iconControl.SetBinding(BaseIcon<TEnum>.IconProperty, new Binding(nameof(Icon), source: this));
		iconControl.SetBinding(Label.FontSizeProperty, new Binding(nameof(Size), source: this));
		iconControl.SetBinding(Label.TextColorProperty, new Binding(nameof(Color), source: this));
		iconControl.SetBinding(VisualElement.BackgroundColorProperty, new Binding(nameof(BackgroundColor), source: this));
		iconControl.SetBinding(BaseIcon<TEnum>.AnimationProperty, new Binding(nameof(Animation), source: this));
		iconControl.SetBinding(BaseIcon<TEnum>.IsAnimationActiveProperty, new Binding(nameof(IsAnimationActive), source: this, mode: BindingMode.TwoWay));

		// Propagation of the BindingContext for MVVM support
		iconControl.SetBinding(BindingContextProperty, new Binding(nameof(BindingContext), source: this));

		return iconControl;
	}

	FontImageSource CreateImageSource()
	{
		var source = new FontImageSource { FontFamily = FontFamily };
		source.SetBinding(FontImageSource.GlyphProperty, new Binding(nameof(Icon), converter: new EnumToIconConverter(), source: this));
		source.SetBinding(FontImageSource.SizeProperty, new Binding(nameof(Size), source: this));
		source.SetBinding(FontImageSource.ColorProperty, new Binding(nameof(Color), source: this));
		return source;
	}

	void ApplyStyles(BindableObject target)
	{
		SetPropertyValue(target, nameof(FontFamily), FontFamily);
		if (Size != 30.0)
		{
			SetPropertyValue(target, "FontSize", Size);
		}

		SetPropertyValue(target, "TextColor", Color);
		SetPropertyValue(target, "ForegroundColor", Color);
		SetPropertyValue(target, nameof(BackgroundColor), BackgroundColor);
	}

	static void SetPropertyValue(BindableObject target, string propertyName, object value)
	{
		var field = target.GetType().GetField($"{propertyName}Property", BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);
		if (field?.GetValue(null) is BindableProperty property)
		{
			target.SetValue(property, value);
		}
	}

	// Static callback called by MAUI when IsAnimationActive changes
	static void OnIsAnimationActivePropertyChanged(BindableObject bindable, object oldValue, object newValue)
	{
		if (bindable is IconExtension<TEnum> extension)
		{
			extension.TriggerAnimationUpdate();
		}
	}

	// Animation management for third-party controls (Label, Button, etc.)
	void AttachAnimationHandler(VisualElement target)
	{
		// We store the target reference without polluting the events
		targetReference = new WeakReference<VisualElement>(target);

		// The animation is triggered immediately if it is set to True in the XAML.
		TriggerAnimationUpdate();
	}

	void TriggerAnimationUpdate()
	{
		if (targetReference != null && targetReference.TryGetTarget(out var visual))
		{
			HandleAnimation(visual);
		}
	}

	void HandleAnimation(VisualElement target)
	{
		if (!target.IsLoaded)
		{
			// We make sure that we only subscribe to Loaded once
			target.Loaded -= OnTargetLoaded;
			target.Loaded += OnTargetLoaded;
			return;
		}

		target.CancelAnimations();

		if (IsAnimationActive && Animation != AnimationType.None)
		{
			Task.Run(async () =>
			{
				await Task.Delay(50); // A short delay to allow the layout to be drawn
				MainThread.BeginInvokeOnMainThread(async () => await RunAnimation(target));
			});
		}
		else
		{
			// A clean visual reset occurs if the animation is stopped.
			target.Rotation = 0;
			target.TranslationX = 0;
			target.Scale = 1;
		}
	}

	void OnTargetLoaded(object? sender, EventArgs e)
	{
		if (sender is VisualElement target)
		{
			target.Loaded -= OnTargetLoaded;
			HandleAnimation(target);
		}
	}

	async Task RunAnimation(VisualElement target)
	{
		try
		{
			switch (Animation)
			{
				case AnimationType.Rotate:
					// Simple rotation (One-shot)
					await target.RotateToAsync(360, 500, Easing.CubicInOut);
					target.Rotation = 0;
					IsAnimationActive = false;
					break;
				case AnimationType.Spin:
					// Infinite rotation
					while (IsAnimationActive)
					{
						await target.RelRotateToAsync(360, 2000, Easing.Linear);
						target.Rotation = 0;
					}
					break;
				case AnimationType.Pulse:
					while (IsAnimationActive)
					{
						await target.ScaleToAsync(1.2, 500, Easing.CubicIn);
						await target.ScaleToAsync(1.0, 500, Easing.CubicOut);
					}
					break;
				case AnimationType.Shake:
					while (IsAnimationActive)
					{
						await target.TranslateToAsync(-5, 0, 50);
						await target.TranslateToAsync(5, 0, 50);
						target.TranslationX = 0;
						await Task.Delay(100);
					}
					break;
			}
		}
		catch (Exception) { }
	}

	/// <summary>
	/// Represents a generic icon component that provides icon rendering functionality for a specified enumeration type.
	/// </summary>
	/// <remarks>This class serves as a base for creating icon components that are parameterized by an
	/// enumeration, allowing for type-safe icon selection. It is intended to be used as a foundation for more specific
	/// icon implementations.</remarks>
	protected partial class GenericIcon : BaseIcon<TEnum> { }
}
