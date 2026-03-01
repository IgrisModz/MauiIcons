using MauiIcons.Core.Controls;
using System.Reflection;

namespace MauiIcons.Core.Extensions;

public class VariableIconExtension<TEnum> : IconExtension<TEnum> where TEnum : struct, Enum
{
    // Propriétés Bindable pour les axes de variation
    public static readonly BindableProperty WeightProperty = BindableProperty.Create(nameof(Weight), typeof(int), typeof(VariableIconExtension<TEnum>), 400);
    public static readonly BindableProperty FillProperty = BindableProperty.Create(nameof(Fill), typeof(int), typeof(VariableIconExtension<TEnum>), 0);
    public static readonly BindableProperty GradeProperty = BindableProperty.Create(nameof(Grade), typeof(int), typeof(VariableIconExtension<TEnum>), 0);
    public static readonly BindableProperty OpticalSizeProperty = BindableProperty.Create(nameof(OpticalSize), typeof(int), typeof(VariableIconExtension<TEnum>), 24);

    public int Weight { get => (int)GetValue(WeightProperty); set => SetValue(WeightProperty, value); }
    public int Fill { get => (int)GetValue(FillProperty); set => SetValue(FillProperty, value); }
    public int Grade { get => (int)GetValue(GradeProperty); set => SetValue(GradeProperty, value); }
    public int OpticalSize { get => (int)GetValue(OpticalSizeProperty); set => SetValue(OpticalSizeProperty, value); }

    public new object ProvideValue(IServiceProvider serviceProvider)
    {
        var result = base.ProvideValue(serviceProvider);

        if (result is BindableObject bindable)
        {
            ApplyVariableStyles(bindable);
        }

        return result;
    }

    // On surcharge la création du contrôle pour utiliser VariableIcon au lieu de BaseIcon
    protected override View CreateBaseIconControl()
    {
        var iconControl = new VariableGenericIcon();

        // Bindings de base (hérités via la logique de IconExtension)
        iconControl.SetBinding(BaseIcon<TEnum>.IconProperty, new Binding(nameof(Icon), source: this));
        iconControl.SetBinding(Label.FontSizeProperty, new Binding(nameof(Size), source: this));
        iconControl.SetBinding(Label.TextColorProperty, new Binding(nameof(Color), source: this));
        iconControl.SetBinding(VisualElement.BackgroundColorProperty, new Binding(nameof(BackgroundColor), source: this));
        iconControl.SetBinding(BaseIcon<TEnum>.AnimationProperty, new Binding(nameof(Animation), source: this));
        iconControl.SetBinding(BaseIcon<TEnum>.IsAnimationActiveProperty, new Binding(nameof(IsAnimationActive), source: this, mode: BindingMode.TwoWay));
        iconControl.SetBinding(BindingContextProperty, new Binding(nameof(BindingContext), source: this));

        // Nouveaux Bindings pour les variations
        iconControl.SetBinding(VariableIconBase<TEnum>.WeightProperty, new Binding(nameof(Weight), source: this));
        iconControl.SetBinding(VariableIconBase<TEnum>.FillProperty, new Binding(nameof(Fill), source: this));
        iconControl.SetBinding(VariableIconBase<TEnum>.GradeProperty, new Binding(nameof(Grade), source: this));
        iconControl.SetBinding(VariableIconBase<TEnum>.OpticalSizeProperty, new Binding(nameof(OpticalSize), source: this));

        //iconControl.Weight = this.Weight;
        //iconControl.Fill = this.Fill;
        //iconControl.Grade = this.Grade;
        //iconControl.OpticalSize = this.OpticalSize;

        return iconControl;
    }

    private void ApplyVariableStyles(BindableObject target)
    {
        // Pour les contrôles standards qui ne supportent pas nativement IVariableIcon, 
        // on essaie quand même d'appliquer les propriétés si elles existent via réflexion (cas de contrôles custom tiers)
        SetPropertyValue(target, nameof(Weight), Weight);
        SetPropertyValue(target, nameof(Fill), Fill);
        SetPropertyValue(target, nameof(Grade), Grade);
        SetPropertyValue(target, nameof(OpticalSize), OpticalSize);
    }

    private static void SetPropertyValue(BindableObject target, string propertyName, object value)
    {
        var field = target.GetType().GetField($"{propertyName}Property", BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);
        if (field?.GetValue(null) is BindableProperty property)
            target.SetValue(property, value);
    }

    // Classe interne concrète basée sur VariableIconBase
    private class VariableGenericIcon : VariableIconBase<TEnum> { }
}
