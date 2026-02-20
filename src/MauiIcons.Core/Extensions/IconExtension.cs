using MauiIcons.Core.Controls;
using MauiIcons.Core.Converters;
using System.Reflection;

namespace MauiIcons.Core.Extensions;

[ContentProperty(nameof(Icon))]
public class IconExtension<TEnum> : BindableObject, IMarkupExtension<object> where TEnum : Enum
{
    private WeakReference<VisualElement>? _targetReference;

    // Propriété Icon avec support Binding
    public static readonly BindableProperty IconProperty = BindableProperty.Create(nameof(Icon), typeof(TEnum), typeof(IconExtension<TEnum>), null);

    public static readonly BindableProperty ColorProperty = BindableProperty.Create(nameof(Color), typeof(Color), typeof(IconExtension<TEnum>), null);

    public static readonly BindableProperty BackgroundColorProperty = BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(IconExtension<TEnum>), null);

    public static readonly BindableProperty SizeProperty = BindableProperty.Create(nameof(Size), typeof(double), typeof(IconExtension<TEnum>), 30.0);

    public static readonly BindableProperty AnimationProperty = BindableProperty.Create(nameof(Animation), typeof(AnimationType), typeof(IconExtension<TEnum>), AnimationType.None);

    public static readonly BindableProperty IsAnimationActiveProperty = BindableProperty.Create(nameof(IsAnimationActive), typeof(bool), typeof(IconExtension<TEnum>), false);

    public TEnum Icon { get => (TEnum)GetValue(IconProperty); set => SetValue(IconProperty, value); }
    public Color Color { get => (Color)GetValue(ColorProperty); set => SetValue(ColorProperty, value); }
    public Color BackgroundColor { get => (Color)GetValue(BackgroundColorProperty); set => SetValue(BackgroundColorProperty, value); }
    public double Size { get => (double)GetValue(SizeProperty); set => SetValue(SizeProperty, value); }
    public AnimationType Animation { get => (AnimationType)GetValue(AnimationProperty); set => SetValue(AnimationProperty, value); }
    public bool IsAnimationActive { get => (bool)GetValue(IsAnimationActiveProperty); set => SetValue(IsAnimationActiveProperty, value); }

    public string FontFamily => Icon is not null ? Icon.GetFontFamily() : string.Empty;

    public virtual object ProvideValue(IServiceProvider serviceProvider)
    {
        var provideValueTarget = serviceProvider.GetService<IProvideValueTarget>();
        if (provideValueTarget == null) return string.Empty;

        // Détection du type de retour attendu (BindingProperty ou PropertyInfo classique)
        Type? targetPropertyType = (provideValueTarget.TargetProperty as BindableProperty)?.ReturnType
                                  ?? (provideValueTarget.TargetProperty as PropertyInfo)?.PropertyType;

        var targetObject = provideValueTarget.TargetObject;

        // La cible attend une ImageSource (ex: Image.Source, ToolbarItem.Icon)
        if (targetPropertyType == typeof(ImageSource) || targetPropertyType == typeof(FontImageSource))
        {
            if (targetObject is Image img)
            {
                img.Aspect = Aspect.Center;
                if (Size > 0) { img.HeightRequest = Size; img.WidthRequest = Size; }
            }
            return CreateImageSource();
        }

        // La cible attend une VUE (ex: ContentView.Content, Frame.Content)
        if (targetPropertyType == typeof(View) || targetPropertyType == typeof(IView))
        {
            return CreateBaseIconControl();
        }

        // GESTION DES CONTRÔLES (Label, Button, etc.)
        if (targetObject is BindableObject bindableTarget)
        {
            ApplyStyles(bindableTarget);

            if (bindableTarget is VisualElement visualTarget)
                AttachAnimationHandler(visualTarget);
        }

        return Icon?.GetDescription() ?? string.Empty;
    }
    private GenericIcon CreateBaseIconControl()
    {
        // On instancie notre classe interne concrète
        var iconControl = new GenericIcon();

        // On lie l'extension au contrôle pour la réactivité bidirectionnelle
        iconControl.SetBinding(BaseIcon<TEnum>.IconProperty, new Binding(nameof(Icon), source: this));
        iconControl.SetBinding(Label.FontSizeProperty, new Binding(nameof(Size), source: this));
        iconControl.SetBinding(Label.TextColorProperty, new Binding(nameof(Color), source: this));
        iconControl.SetBinding(VisualElement.BackgroundColorProperty, new Binding(nameof(BackgroundColor), source: this));
        iconControl.SetBinding(BaseIcon<TEnum>.AnimationProperty, new Binding(nameof(Animation), source: this));
        iconControl.SetBinding(BaseIcon<TEnum>.IsAnimationActiveProperty, new Binding(nameof(IsAnimationActive), source: this, mode: BindingMode.TwoWay));

        // Propagation du BindingContext pour le support MVVM
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
        if (Color != null)
        {
            SetPropertyValue(target, "TextColor", Color);
            SetPropertyValue(target, "ForegroundColor", Color);
        }
        if (BackgroundColor != null) SetPropertyValue(target, nameof(BackgroundColor), BackgroundColor);
    }

    private static void SetPropertyValue(BindableObject target, string propertyName, object value)
    {
        var field = target.GetType().GetField($"{propertyName}Property", BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);
        if (field?.GetValue(null) is BindableProperty property)
            target.SetValue(property, value);
    }

    // Gestion des animations pour les contrôles tiers (Label, Button)
    private void AttachAnimationHandler(VisualElement target)
    {
        PropertyChanged -= OnExtensionPropertyChanged;
        _targetReference = new WeakReference<VisualElement>(target);
        PropertyChanged += OnExtensionPropertyChanged;
    }

    private void OnExtensionPropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(IsAnimationActive) && _targetReference != null && _targetReference.TryGetTarget(out var visual))
            HandleAnimation(visual);
    }

    private void HandleAnimation(VisualElement target)
    {
        // Indispensable : On ne peut pas animer un contrôle non monté
        if (!target.IsLoaded)
        {
            target.Loaded += (s, e) => HandleAnimation(target);
            return;
        }

        // Sécurité : Annuler les animations en cours avant de relancer
        target.CancelAnimations();

        if (IsAnimationActive && Animation != AnimationType.None)
        {
            // On lance dans une tâche séparée pour ne pas bloquer l'UI
            Task.Run(async () => {
                await Task.Delay(100); // Petit délai pour laisser le rendu natif se stabiliser
                MainThread.BeginInvokeOnMainThread(async () => await RunAnimation(target));
            });
        }
    }

    private async Task RunAnimation(VisualElement target)
    {
        switch (Animation)
        {
            case AnimationType.Rotate:
                // Rotation simple (One-shot)
                await target.RotateToAsync(360, 500, Easing.CubicInOut);
                target.Rotation = 0;
                IsAnimationActive = false;
                break;
            case AnimationType.Spin:
                // Rotation infinie
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

    // Classe interne pour instancier BaseIcon<TEnum> qui est abstraite
    private class GenericIcon : BaseIcon<TEnum> { }
}
