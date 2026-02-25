using Microsoft.Maui.Controls;

namespace MauiIcons.Core.Controls;

public class VariableIconBase<TEnum> : BaseIcon<TEnum>, IVariableIcon where TEnum : struct, Enum
{
    public static readonly BindableProperty WeightProperty = BindableProperty.Create(nameof(Weight), typeof(int), typeof(VariableIconBase<TEnum>), 400, propertyChanged: OnVariationChanged);
    public static readonly BindableProperty FillProperty = BindableProperty.Create(nameof(Fill), typeof(int), typeof(VariableIconBase<TEnum>), 0, propertyChanged: OnVariationChanged);
    public static readonly BindableProperty GradeProperty = BindableProperty.Create(nameof(Grade), typeof(int), typeof(VariableIconBase<TEnum>), 0, propertyChanged: OnVariationChanged);
    public static readonly BindableProperty OpticalSizeProperty = BindableProperty.Create(nameof(OpticalSize), typeof(int), typeof(VariableIconBase<TEnum>), 24, propertyChanged: OnVariationChanged);

    public int Weight { get => (int)GetValue(WeightProperty); set => SetValue(WeightProperty, value); }
    public int Fill { get => (int)GetValue(FillProperty); set => SetValue(FillProperty, value); }
    public int Grade { get => (int)GetValue(GradeProperty); set => SetValue(GradeProperty, value); }
    public int OpticalSize { get => (int)GetValue(OpticalSizeProperty); set => SetValue(OpticalSizeProperty, value); }

    private static void OnVariationChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is VariableIconBase<TEnum> icon)
        {
            icon.Handler?.UpdateValue(nameof(Weight));
        }
    }
}
