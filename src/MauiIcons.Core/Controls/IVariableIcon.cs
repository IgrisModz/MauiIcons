namespace MauiIcons.Core.Controls;

public interface IVariableIcon : ILabel
{
    int Weight { get; }
    int Fill { get; }
    int Grade { get; }
    int OpticalSize { get; }
}
