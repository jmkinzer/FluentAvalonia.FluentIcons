using System.Reflection;
using Avalonia.Media;
using SkiaSharp;

namespace FluentAvalonia.FluentIcons.Helpers;

internal static class IconHelper
{
    public static readonly SKFont FilledFont;
    public static readonly SKFont RegularFont;

    static IconHelper()
    {
        RegularFont = LoadFont("FluentAvalonia.FluentIcons.Resources.FluentSystemIcons-Regular.ttf");
        FilledFont = LoadFont("FluentAvalonia.FluentIcons.Resources.FluentSystemIcons-Filled.ttf");
    }

    public static PathGeometry GetPathGeometryFromIcon(FluentIconSymbol icon)
    {
        var isRegular = icon.ToString().EndsWith("Regular");
        var font = isRegular ? RegularFont : FilledFont;

        // Filled enums values are multiplied by 100 because ToString() doesn't work well when the enum has
        // duplicate values
        var value = isRegular ? (int)icon : (int)icon / 100;
        return PathGeometry.Parse(font.GetGlyphPath(font.GetGlyph(value)).ToSvgPathData());
    }

    private static SKFont LoadFont(string resource)
    {
        using var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resource)!;
        return SKTypeface.FromStream(stream).ToFont();
    }
}