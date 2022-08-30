using Avalonia.Markup.Xaml;

namespace FluentAvalonia.FluentIcons;

[Obsolete("Use FluentIconExtension instead. This will be removed when FluentAvalonia 2.0 is released.")]
public class FilledFluentIconExtension : MarkupExtension
{
    private readonly FilledFluentIconSymbol _icon;

    public FilledFluentIconExtension(FilledFluentIconSymbol icon)
    {
        _icon = icon;
    }

    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        return new FilledFluentIcon
        {
            Icon = _icon
        };
    }
}