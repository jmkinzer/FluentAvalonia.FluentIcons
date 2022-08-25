using System.Reflection;
using Avalonia;
using Avalonia.Media;
using FluentAvalonia.UI.Controls;
using SkiaSharp;

namespace FluentAvalonia.FluentIcons;

public class RegularFluentIcon : PathIcon
{
    public static readonly StyledProperty<RegularFluentIconSymbol> IconProperty =
        AvaloniaProperty.Register<RegularFluentIcon, RegularFluentIconSymbol>(nameof(Icon));

    private static readonly SKFont Font;

    static RegularFluentIcon()
    {
        var assembly = Assembly.GetExecutingAssembly();
        var stream =
            assembly.GetManifestResourceStream("FluentAvalonia.FluentIcons.Resources.FluentSystemIcons-Regular.ttf");
        Font = SKTypeface.FromStream(stream).ToFont();
    }

    public RegularFluentIconSymbol Icon
    {
        get => GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }

    protected override void OnPropertyChanged<T>(AvaloniaPropertyChangedEventArgs<T> change)
    {
        base.OnPropertyChanged(change);

        if (change.Property == IconProperty)
        {
            Data = PathGeometry.Parse(Font.GetGlyphPath(Font.GetGlyph((int)Icon)).ToSvgPathData());
        }
    }
}