using MauiIcons.Core.Controls;
using MauiIcons.Core.Converters;
using System.Reflection;

namespace MauiIcons.Core.Extensions;

[ContentProperty(nameof(Icon))]
public class IconExtension<TEnum> : BindableObject, IMarkupExtension<object> where TEnum : struct, Enum
{
    private WeakReference<VisualElement>? _targetReference;

    public static readonly BindableProperty IconProperty = BindableProperty.Create(nameof(Icon), typeof(TEnum), typeof(IconExtension<TEnum>), default(TEnum));
    public static readonly BindableProperty ColorProperty = BindableProperty.Create(nameof(Color), typeof(Color), typeof(IconExtension<TEnum>), null);
    public static readonly BindableProperty BackgroundColorProperty = BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(IconExtension<TEnum>), null);
    public static readonly BindableProperty SizeProperty = BindableProperty.Create(nameof(Size), typeof(double), typeof(IconExtension<TEnum>), 30.0);
    public static readonly BindableProperty AnimationProperty = BindableProperty.Create(nameof(Animation), typeof(AnimationType), typeof(IconExtension<TEnum>), AnimationType.None);
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
        if (provideValueTarget == null) return string.Empty;

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
                AttachAnimationHandler(visualTarget);
        }

        return Glyph;
    }
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

    private FontImageSource CreateImageSource()
    {
        var source = new FontImageSource { FontFamily = FontFamily };
        source.SetBinding(FontImageSource.GlyphProperty, new Binding(nameof(Icon), converter: new EnumToIconConverter(), source: this));
        source.SetBinding(FontImageSource.SizeProperty, new Binding(nameof(Size), source: this));
        source.SetBinding(FontImageSource.ColorProperty, new Binding(nameof(Color), source: this));
        return source;
    }

    private void ApplyStyles(BindableObject target)
    {
        SetPropertyValue(target, nameof(FontFamily), FontFamily);
        if (Size != 30.0) SetPropertyValue(target, "FontSize", Size);
        SetPropertyValue(target, "TextColor", Color);
        SetPropertyValue(target, "ForegroundColor", Color);
        SetPropertyValue(target, nameof(BackgroundColor), BackgroundColor);
    }

    private static void SetPropertyValue(BindableObject target, string propertyName, object value)
    {
        var field = target.GetType().GetField($"{propertyName}Property", BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);
        if (field?.GetValue(null) is BindableProperty property)
            target.SetValue(property, value);
    }

    // Static callback called by MAUI when IsAnimationActive changes
    private static void OnIsAnimationActivePropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is IconExtension<TEnum> extension)
        {
            extension.TriggerAnimationUpdate();
        }
    }

    // Animation management for third-party controls (Label, Button, etc.)
    private void AttachAnimationHandler(VisualElement target)
    {
        // We store the target reference without polluting the events
        _targetReference = new WeakReference<VisualElement>(target);

        // The animation is triggered immediately if it is set to True in the XAML.
        TriggerAnimationUpdate();
    }

    private void TriggerAnimationUpdate()
    {
        if (_targetReference != null && _targetReference.TryGetTarget(out var visual))
        {
            HandleAnimation(visual);
        }
    }

    private void HandleAnimation(VisualElement target)
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

    private void OnTargetLoaded(object? sender, EventArgs e)
    {
        if (sender is VisualElement target)
        {
            target.Loaded -= OnTargetLoaded;
            HandleAnimation(target);
        }
    }

    private async Task RunAnimation(VisualElement target)
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

    // Inner class for instantiating BaseIcon<TEnum> which is abstract
    protected class GenericIcon : BaseIcon<TEnum> { }
}
