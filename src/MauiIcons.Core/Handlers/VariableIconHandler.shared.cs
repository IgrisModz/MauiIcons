using MauiIcons.Core.Controls;
using Microsoft.Maui.Handlers;

namespace MauiIcons.Core.Handlers;

public partial class VariableIconHandler : LabelHandler
{
    public static IPropertyMapper<IVariableIcon, VariableIconHandler> VariableIconMapper = new PropertyMapper<IVariableIcon, VariableIconHandler>(LabelHandler.Mapper)
    {
        [nameof(IVariableIcon.Weight)] = MapVariation,
        [nameof(IVariableIcon.Fill)] = MapVariation,
        [nameof(IVariableIcon.Grade)] = MapVariation,
        [nameof(IVariableIcon.OpticalSize)] = MapVariation,
    };

    public VariableIconHandler() : base(VariableIconMapper)
    {
    }

    public VariableIconHandler(IPropertyMapper mapper) : base(mapper ?? VariableIconMapper)
    {
    }

    static void MapVariation(VariableIconHandler handler, IVariableIcon icon)
    {
        handler.ApplyVariations();
    }

    partial void ApplyVariations();
}
