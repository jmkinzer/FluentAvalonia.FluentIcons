using System.Reflection;
using Avalonia;
using Avalonia.Media;
using FluentAvalonia.UI.Controls;
using SkiaSharp;

namespace FluentAvalonia.FluentIcons;

public class FilledFluentIcon : PathIcon
{
    public static readonly StyledProperty<FilledFluentIconSymbol> IconProperty =
        AvaloniaProperty.Register<RegularFluentIcon, FilledFluentIconSymbol>(nameof(Icon));

    private static readonly SKFont Font;

    static FilledFluentIcon()
    {
        var stream = Assembly.GetExecutingAssembly()
            .GetManifestResourceStream("FluentAvalonia.FluentIcons.Resources.FluentSystemIcons-Filled.ttf");
        Font = SKTypeface.FromStream(stream).ToFont();
    }

    public FilledFluentIconSymbol Icon
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