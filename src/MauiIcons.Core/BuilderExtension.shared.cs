using MauiIcons.Core.Controls;
using MauiIcons.Core.Handlers;

namespace MauiIcons.Core;

/// <summary>
/// Provides extension methods for configuring MauiIcons support in a .NET MAUI application.
/// </summary>
public static class BuilderExtension
{
	/// <summary>
	/// Configures the application to support MauiIcons by registering the necessary icon handlers.
	/// </summary>
	/// <remarks>Call this method during application startup to enable MauiIcons support on supported
	/// platforms. This method has no effect on platforms where MauiIcons is not supported.</remarks>
	/// <param name="builder">The builder used to configure the Maui application pipeline.</param>
	/// <returns>The same MauiAppBuilder instance, enabling method chaining.</returns>
	public static MauiAppBuilder UseMauiIconsCore(this MauiAppBuilder builder)
	{
		builder.ConfigureMauiHandlers(handlers =>
	   {
		   handlers.AddHandler<IVariableIcon, VariableIconHandler>();
	   });
		return builder;
	}
}