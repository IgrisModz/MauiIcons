using MauiIcons.Core.Controls;
using System.Reflection;

namespace MauiIcons.Core.Extensions;

/// <summary>
/// Provides a markup extension for rendering variable icons with customizable style properties such as weight, fill,
/// grade, and optical size in XAML.
/// </summary>
/// <remarks>This extension enables dynamic styling of icons in XAML by exposing additional properties for
/// variable font or graphic customization. It extends the base IconExtension to support advanced scenarios where icon
/// appearance needs to be adjusted at runtime or through data binding. The extension is typically used in XAML to
/// declaratively specify icon variations without manual code updates.</remarks>
/// <typeparam name="TEnum">The enumeration type that defines the available icons. Must be a struct and an enumeration.</typeparam>
[ContentProperty(nameof(Icon))]
public partial class VariableIconExtension<TEnum> : IconExtension<TEnum> where TEnum : struct, Enum
{
	/// <summary>
	/// Identifies the Weight bindable property, which represents the font weight for the icon extension.
	/// </summary>
	/// <remarks>The default value is 400, corresponding to the normal font weight. This property can be used in
	/// data binding scenarios to control the visual weight of the icon.</remarks>
	public static readonly BindableProperty WeightProperty = BindableProperty.Create(nameof(Weight), typeof(int), typeof(VariableIconExtension<TEnum>), 400);

	/// <summary>
	/// Identifies the Fill bindable property, which represents the fill value for the icon extension.
	/// </summary>
	/// <remarks>This property can be used to bind the fill value in XAML or code, enabling dynamic updates to the
	/// icon's appearance. The default value is 0.</remarks>
	public static readonly BindableProperty FillProperty = BindableProperty.Create(nameof(Fill), typeof(int), typeof(VariableIconExtension<TEnum>), 0);

	/// <summary>
	/// Identifies the Grade bindable property, which represents the grade value for the VariableIconExtension.
	/// </summary>
	/// <remarks>This property can be used for data binding in Xamarin.Forms to track or update the grade value
	/// associated with the extension. The default value is 0.</remarks>
	public static readonly BindableProperty GradeProperty = BindableProperty.Create(nameof(Grade), typeof(int), typeof(VariableIconExtension<TEnum>), 0);

	/// <summary>
	/// Identifies the bindable property used to set the optical size for the icon extension.
	/// </summary>
	/// <remarks>This property enables data binding for the optical size of icons in XAML. The default value is 24.
	/// Changing this property affects the rendering size of the icon.</remarks>
	public static readonly BindableProperty OpticalSizeProperty = BindableProperty.Create(nameof(OpticalSize), typeof(int), typeof(VariableIconExtension<TEnum>), 24);

	/// <summary>
	/// Gets or sets the weight value associated with the object.
	/// </summary>
	public int Weight { get => (int)GetValue(WeightProperty); set => SetValue(WeightProperty, value); }

	/// <summary>
	/// Gets or sets the fill value associated with the object.
	/// </summary>
	public int Fill { get => (int)GetValue(FillProperty); set => SetValue(FillProperty, value); }

	/// <summary>
	/// Gets or sets the grade value associated with the object.
	/// </summary>
	public int Grade { get => (int)GetValue(GradeProperty); set => SetValue(GradeProperty, value); }

	/// <summary>
	/// Gets or sets the optical size used for rendering the font or graphic element.
	/// </summary>
	public int OpticalSize { get => (int)GetValue(OpticalSizeProperty); set => SetValue(OpticalSizeProperty, value); }

	/// <summary>
	/// Returns an object that is provided as the value of the target property for this markup extension, applying
	/// variable styles if the result is a BindableObject.
	/// </summary>
	/// <remarks>This override extends the base ProvideValue behavior by applying variable styles to the
	/// result if it is a BindableObject. This enables dynamic styling scenarios in XAML markup extensions.</remarks>
	/// <param name="serviceProvider">An object that can provide services for the markup extension. Typically used to obtain context information about
	/// the target property.</param>
	/// <returns>The object to set on the property where the extension is applied. If the base implementation returns a
	/// BindableObject, variable styles are applied before returning.</returns>
	public new object ProvideValue(IServiceProvider serviceProvider)
	{
		var result = base.ProvideValue(serviceProvider);

		if (result is BindableObject bindable)
		{
			ApplyVariableStyles(bindable);
		}

		return result;
	}

	/// <summary>
	/// Creates and configures a variable icon control with bindings for icon properties and visual attributes.
	/// </summary>
	/// <remarks>This method overrides the base icon control creation to use a variable icon, enabling support for
	/// additional properties such as weight, fill, grade, and optical size. The returned control is fully bound to the
	/// relevant properties, ensuring dynamic updates and two-way binding for animation state.</remarks>
	/// <returns>A configured instance of the variable icon control representing the icon with applied bindings.</returns>
	protected override View CreateBaseIconControl()
	{
		var iconControl = new VariableGenericIcon();

		// Basic bindings (inherited via IconExtension logic)
		iconControl.SetBinding(BaseIcon<TEnum>.IconProperty, new Binding(nameof(Icon), source: this));
		iconControl.SetBinding(Label.FontSizeProperty, new Binding(nameof(Size), source: this));
		iconControl.SetBinding(Label.TextColorProperty, new Binding(nameof(Color), source: this));
		iconControl.SetBinding(VisualElement.BackgroundColorProperty, new Binding(nameof(BackgroundColor), source: this));
		iconControl.SetBinding(BaseIcon<TEnum>.AnimationProperty, new Binding(nameof(Animation), source: this));
		iconControl.SetBinding(BaseIcon<TEnum>.IsAnimationActiveProperty, new Binding(nameof(IsAnimationActive), source: this, mode: BindingMode.TwoWay));
		iconControl.SetBinding(BindingContextProperty, new Binding(nameof(BindingContext), source: this));

		// New bindings for the variations
		iconControl.SetBinding(VariableIconBase<TEnum>.WeightProperty, new Binding(nameof(Weight), source: this));
		iconControl.SetBinding(VariableIconBase<TEnum>.FillProperty, new Binding(nameof(Fill), source: this));
		iconControl.SetBinding(VariableIconBase<TEnum>.GradeProperty, new Binding(nameof(Grade), source: this));
		iconControl.SetBinding(VariableIconBase<TEnum>.OpticalSizeProperty, new Binding(nameof(OpticalSize), source: this));

		return iconControl;
	}

	void ApplyVariableStyles(BindableObject target)
	{
		// For standard controls that do not natively support IVariableIcon, 
		// we still try to apply the properties if they exist via reflection (in the case of custom third-party controls).
		SetPropertyValue(target, nameof(Weight), Weight);
		SetPropertyValue(target, nameof(Fill), Fill);
		SetPropertyValue(target, nameof(Grade), Grade);
		SetPropertyValue(target, nameof(OpticalSize), OpticalSize);
	}

	static void SetPropertyValue(BindableObject target, string propertyName, object value)
	{
		var field = target.GetType().GetField($"{propertyName}Property", BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);
		if (field?.GetValue(null) is BindableProperty property)
		{
			target.SetValue(property, value);
		}
	}

	// Concrete inner class based on VariableIconBase
	partial class VariableGenericIcon : VariableIconBase<TEnum> { }
}
