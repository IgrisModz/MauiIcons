using MauiIcons.Core.Extensions;
using System.ComponentModel;

namespace MauiIcons.Core.Controls;

public enum AnimationType
{
    None,
    Spin,   // Rotation infinie (ex: spinner)
    Pulse,  // Grossit et rétrécit
    Shake,  // Tremblement latéral
    Rotate  // Rotation simple une seule fois
}

public abstract class BaseIcon<TEnum> : Label where TEnum : struct, Enum
{
    private CancellationTokenSource? _animationSource;
    
    public static readonly BindableProperty IconProperty = BindableProperty.Create(nameof(Icon), typeof(TEnum), typeof(BaseIcon<TEnum>), default(TEnum), propertyChanged: OnIconChanged);
    public static readonly BindableProperty AnimationProperty = BindableProperty.Create(nameof(Animation), typeof(AnimationType), typeof(BaseIcon<TEnum>), AnimationType.None);
    public static readonly BindableProperty IsAnimationActiveProperty = BindableProperty.Create(nameof(IsAnimationActive), typeof(bool), typeof(BaseIcon<TEnum>), false, propertyChanged: OnIsAnimationActiveChanged);
    
    public TEnum Icon { get => (TEnum)GetValue(IconProperty); set => SetValue(IconProperty, value); }
    public AnimationType Animation { get => (AnimationType)GetValue(AnimationProperty); set => SetValue(AnimationProperty, value); }
    public bool IsAnimationActive { get => (bool)GetValue(IsAnimationActiveProperty); set => SetValue(IsAnimationActiveProperty, value); }



    [EditorBrowsable(EditorBrowsableState.Never)]
    public TEnum? IconSuggestions => default;

    public BaseIcon()
    {
        VerticalTextAlignment = TextAlignment.Center;
        HorizontalTextAlignment = TextAlignment.Center;
        FontSize = 30.0; // Taille par défaut de l'icône
        UpdateIcon(Icon);
    }

    private static void OnIconChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is BaseIcon<TEnum> control && newValue is TEnum iconEnum)
        {
            control.UpdateIcon(iconEnum);
        }
    }

    private void UpdateIcon(TEnum iconEnum)
    {
        FontFamily = iconEnum.GetFontFamily();
        Text = iconEnum.GetGlyph();
    }

    private static void OnIsAnimationActiveChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is BaseIcon<TEnum> control)
        {
            if ((bool)newValue) control.StartAnimation();
            else control.StopAnimation();
        }
    }

    private async void StartAnimation()
    {
        StopAnimation(); // Security

        _animationSource?.Dispose();
        _animationSource = new CancellationTokenSource();
        var token = _animationSource.Token;

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
                    // Rotation simple (One-shot)
                    await this.RotateToAsync(360, 500, Easing.CubicInOut);
                    Rotation = 0;
                    IsAnimationActive = false; //Auto reset
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
        _animationSource?.Cancel();
        this.CancelAnimations();
        Rotation = 0;
        Scale = 1;
        TranslationX = 0;
    }
}
