using Avalonia.Markup.Xaml;

namespace FluentAvalonia.FluentIcons;

public class FluentIconExtension : MarkupExtension
{
    private readonly FluentIconSymbol _icon;

    public FluentIconExtension(FluentIconSymbol icon)
    {
        _icon = icon;
    }

    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        return new FluentIcon
        {
            Icon = _icon
        };
    }
}