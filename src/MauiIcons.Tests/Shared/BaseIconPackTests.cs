using System.Reflection;

namespace MauiIcons.Tests.Shared;

public abstract class BaseIconPackTests<TEnum, TControl, TExtension>
    where TEnum : struct, Enum
    where TControl : BaseIcon<TEnum>, new()
    where TExtension : IconExtension<TEnum>, new()
{
    [Fact]
    public void All_Enum_Values_Should_Have_Valid_Unicode_Description()
    {
        foreach (TEnum icon in Enum.GetValues<TEnum>())
        {
            var description = icon.GetDescription();

            Assert.NotNull(description);
            Assert.NotEmpty(description);

            // Vérifie que l'attribut Description existe réellement sur la valeur d'énumération
            var fieldInfo = typeof(TEnum).GetField(icon.ToString());
            Assert.NotNull(fieldInfo);
            var descriptionAttribute = fieldInfo.GetCustomAttribute<System.ComponentModel.DescriptionAttribute>();
            Assert.NotNull(descriptionAttribute);
        }
    }

    // Note: Les tests suivants ont été supprimés car ils nécessitent l'instanciation de contrôles/extensions UI MAUI
    // (BindableObject), ce qui n'est pas possible dans un environnement de test unitaire headless :
    // - Extension_Should_Return_Correct_Type : IconExtension<TEnum> hérite de BindableObject qui requiert le Dispatcher MAUI
    // - Control_Should_Assign_Correct_FontFamily_By_Default : BaseIcon<TEnum> hérite également de BindableObject
    // Pour tester les contrôles et extensions UI, utilisez des tests d'intégration avec un hôte MAUI approprié.
}
