using System.Reflection;
using MauiIcons.Core.Attributes;

namespace MauiIcons.Tests.Shared;

public abstract class BaseIconPackTests<TEnum, TControl, TExtension>
    where TEnum : struct, Enum
    where TControl : BaseIcon<TEnum>, new()
    where TExtension : IconExtension<TEnum>, new()
{
    [Fact]
    public void Enum_Should_Have_IconFont_Attribute()
    {
        var iconFontAttribute = typeof(TEnum).GetCustomAttribute<IconFontAttribute>();

        Assert.NotNull(iconFontAttribute);
        Assert.NotNull(iconFontAttribute.FontFamily);
        Assert.NotEmpty(iconFontAttribute.FontFamily);
    }

    [Fact]
    public void All_Enum_Values_Should_Have_Valid_Unicode_Glyph()
    {
        foreach (TEnum icon in Enum.GetValues<TEnum>())
        {
            var glyph = icon.GetGlyph();

            Assert.NotNull(glyph);
            Assert.NotEmpty(glyph);
        }
    }

    // Maybe later to test if there are no duplicate values in the enum, but it can be tricky if some icons intentionally share the same glyph (e.g., aliases)
    //[Fact]
    //public void All_Enum_Values_Should_Have_Unique_Values()
    //{
    //    var values = Enum.GetValues<TEnum>()
    //        .Select(icon => Convert.ToInt32(icon))
    //        .ToList();

    //    var duplicates = values.GroupBy(x => x)
    //        .Where(g => g.Count() > 1)
    //        .Select(g => g.Key)
    //        .ToList();

    //    Assert.Empty(duplicates);
    //}

    [Fact]
    public void Enum_Should_Have_At_Least_One_Value()
    {
        var values = Enum.GetValues<TEnum>();
        Assert.NotEmpty(values);
    }

    [Fact]
    public void All_Enum_Values_Should_Have_Valid_Names()
    {
        foreach (TEnum icon in Enum.GetValues<TEnum>())
        {
            var name = icon.ToString();

            Assert.NotNull(name);
            Assert.NotEmpty(name);
            Assert.DoesNotContain(" ", name); // Pas d'espaces dans les noms
            Assert.Matches("^[A-Za-z0-9_]+$", name); // Uniquement des caractères alphanumériques et underscores
        }
    }

    [Fact]
    public void GetGlyph_Should_Return_Single_Character_Or_Surrogate_Pair()
    {
        foreach (TEnum icon in Enum.GetValues<TEnum>())
        {
            var glyph = icon.GetGlyph();

            // Un glyphe Unicode valide devrait avoir 1 ou 2 caractères (paire de substitution)
            Assert.InRange(glyph.Length, 1, 2);
        }
    }

    // Note: Les tests suivants ont été supprimés car ils nécessitent l'instanciation de contrôles/extensions UI MAUI
    // (BindableObject), ce qui n'est pas possible dans un environnement de test unitaire headless :
    // - Extension_Should_Return_Correct_Type : IconExtension<TEnum> hérite de BindableObject qui requiert le Dispatcher MAUI
    // - Control_Should_Assign_Correct_FontFamily_By_Default : BaseIcon<TEnum> hérite également de BindableObject
    // Pour tester les contrôles et extensions UI, utilisez des tests d'intégration avec un hôte MAUI approprié.
}
