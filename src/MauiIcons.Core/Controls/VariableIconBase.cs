namespace MauiIcons.Core.Controls;

/// <summary>
/// Provides a base class for variable icons that support customizable visual variations such as weight, fill, grade,
/// and optical size.
/// </summary>
/// <remarks>This class is intended for use in scenarios where icon appearance needs to be dynamically adjusted
/// based on visual parameters. It exposes bindable properties for each supported variation, enabling integration with
/// data binding frameworks such as Xamarin.Forms or .NET MAUI.</remarks>
/// <typeparam name="TEnum">The enumeration type that defines the available icon variants.</typeparam>
public partial class VariableIconBase<TEnum> : BaseIcon<TEnum>, IVariableIcon where TEnum : struct, Enum
{
	/// <summary>
	/// Identifies the Weight bindable property, which represents the stroke weight for the icon.
	/// </summary>
	/// <remarks>The default value is 400. Changing this property triggers the icon variation update. This property
	/// is typically used in data binding scenarios to control the visual thickness of the icon.</remarks>
    public static readonly BindableProperty WeightProperty = BindableProperty.Create(nameof(Weight), typeof(int), typeof(VariableIconBase<TEnum>), 400, propertyChanged: OnVariationChanged);

	/// <summary>
	/// Identifies the Fill bindable property, which determines the fill level for the icon.
	/// </summary>
	/// <remarks>This property can be used for data binding in Xamarin.Forms to control how much of the icon is
	/// filled. Changing the value triggers the icon variation update.</remarks>
    public static readonly BindableProperty FillProperty = BindableProperty.Create(nameof(Fill), typeof(int), typeof(VariableIconBase<TEnum>), 0, propertyChanged: OnVariationChanged);

	/// <summary>
	/// Identifies the Grade bindable property, which represents the grade value for the VariableIconBase control.
	/// </summary>
	/// <remarks>Use this property to bind or set the grade value in data templates or styles. The default value is
	/// 0. Changes to this property trigger the OnVariationChanged callback, which may update the icon's
	/// appearance.</remarks>
    public static readonly BindableProperty GradeProperty = BindableProperty.Create(nameof(Grade), typeof(int), typeof(VariableIconBase<TEnum>), 0, propertyChanged: OnVariationChanged);

	/// <summary>
	/// Identifies the OpticalSize bindable property, which specifies the optical size of the icon in points.
	/// </summary>
	/// <remarks>The default value is 24. Changing this property updates the icon's visual appearance to match the
	/// specified optical size. This property is typically used to adjust icon rendering for different display
	/// contexts.</remarks>
    public static readonly BindableProperty OpticalSizeProperty = BindableProperty.Create(nameof(OpticalSize), typeof(int), typeof(VariableIconBase<TEnum>), 24, propertyChanged: OnVariationChanged);

    /// <summary>
    /// Gets or sets the weight value associated with the element.
    /// </summary>
    public int Weight { get => (int)GetValue(WeightProperty); set => SetValue(WeightProperty, value); }
    
    /// <summary>
    /// Gets or sets the fill value for the associated element.
    /// </summary>
    public int Fill { get => (int)GetValue(FillProperty); set => SetValue(FillProperty, value); }
    
    /// <summary>
    /// Gets or sets the grade value associated with the current instance.
    /// </summary>
    public int Grade { get => (int)GetValue(GradeProperty); set => SetValue(GradeProperty, value); }

    /// <summary>
    /// Gets or sets the optical size value for the associated element, which may influence its visual appearance based on size-related variations.
    /// </summary>
    public int OpticalSize { get => (int)GetValue(OpticalSizeProperty); set => SetValue(OpticalSizeProperty, value); }

    static void OnVariationChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is VariableIconBase<TEnum> icon)
        {
            icon.Handler?.UpdateValue(nameof(Weight));
        }
    }
}
