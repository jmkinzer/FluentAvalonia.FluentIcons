using Avalonia;
using Avalonia.Media;
using FluentAvalonia.FluentIcons.Helpers;
using FluentAvalonia.UI.Controls;

namespace FluentAvalonia.FluentIcons;

[Obsolete("Use FluentIcon instead. This will be removed when FluentAvalonia 2.0 is released.")]
public class FilledFluentIcon : PathIcon
{
    public static readonly StyledProperty<FilledFluentIconSymbol> IconProperty =
        AvaloniaProperty.Register<FilledFluentIcon, FilledFluentIconSymbol>(nameof(Icon));

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
            var font = IconHelper.FilledFont;
            Data = PathGeometry.Parse(font.GetGlyphPath(font.GetGlyph((int)Icon)).ToSvgPathData());
        }
    }
}