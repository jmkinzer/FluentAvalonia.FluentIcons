using Avalonia.Markup.Xaml;

namespace FluentAvalonia.FluentIcons;

public class FluentIconSourceExtension : MarkupExtension
{
    private readonly FluentIconSymbol _icon;

    public FluentIconSourceExtension(FluentIconSymbol icon)
    {
        _icon = icon;
    }

    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        return new FluentIconSource
        {
            Icon = _icon
        };
    }
}