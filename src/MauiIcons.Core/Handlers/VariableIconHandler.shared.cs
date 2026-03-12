using MauiIcons.Core.Controls;
using Microsoft.Maui.Handlers;

namespace MauiIcons.Core.Handlers;

/// <summary>
/// Handles the mapping and application of variable icon properties for controls implementing the IVariableIcon
/// interface.
/// </summary>
/// <remarks>VariableIconHandler extends LabelHandler to support additional properties specific to variable icons,
/// such as weight, fill, grade, and optical size. It uses a property mapper to associate these properties with their
/// corresponding update logic. This handler is intended for use with controls that require dynamic icon variation based
/// on these properties.</remarks>
public partial class VariableIconHandler : LabelHandler
{
    static readonly IPropertyMapper<IVariableIcon, VariableIconHandler> variableIconMapper = new PropertyMapper<IVariableIcon, VariableIconHandler>(Mapper)
    {
        [nameof(IVariableIcon.Weight)] = MapVariation,
        [nameof(IVariableIcon.Fill)] = MapVariation,
        [nameof(IVariableIcon.Grade)] = MapVariation,
        [nameof(IVariableIcon.OpticalSize)] = MapVariation,
    };
	/// <summary>
	/// Initializes a new instance of the VariableIconHandler class with the default property mapper for variable icons.
	/// </summary>
	/// <remarks>The default property mapper includes mappings for weight, fill, grade, and optical size properties, which are essential for handling variable icons. This constructor allows for easy instantiation of the handler with the necessary mappings already in place.</remarks>
	public VariableIconHandler() : base(variableIconMapper)
    {
    }

	/// <summary>
	/// Initializes a new instance of the VariableIconHandler class with a custom property mapper.
	/// </summary>
	/// <param name="mapper">The custom property mapper to use for this handler. If null, the default variable icon mapper is used.</param>
	public VariableIconHandler(IPropertyMapper mapper) : base(mapper ?? variableIconMapper)
    {
    }

    static void MapVariation(VariableIconHandler handler, IVariableIcon icon)
    {
        handler.ApplyVariations();
    }

    partial void ApplyVariations();
}
