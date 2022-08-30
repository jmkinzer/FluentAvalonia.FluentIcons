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
        var assembly = Assembly.GetExecutingAssembly();
        using var stream =
            assembly.GetManifestResourceStream("FluentAvalonia.FluentIcons.Resources.FluentSystemIcons-Regular.ttf");
        RegularFont = SKTypeface.FromStream(stream).ToFont();

        using var stream2 =
            assembly.GetManifestResourceStream("FluentAvalonia.FluentIcons.Resources.FluentSystemIcons-Filled.ttf");
        FilledFont = SKTypeface.FromStream(stream2).ToFont();
    }

    public static PathGeometry GetPathGeometryFromIcon(FluentIconSymbol icon)
    {
        var font = icon.ToString().EndsWith("Regular") ? RegularFont : FilledFont;

        // Filled enums values are multiplied by 100 because ToString() doesn't work well when the enum has
        // duplicate values
        var value = icon.ToString().EndsWith("Regular") ? (int)icon : (int)icon / 100;
        return PathGeometry.Parse(font.GetGlyphPath(font.GetGlyph(value)).ToSvgPathData());
    }
}