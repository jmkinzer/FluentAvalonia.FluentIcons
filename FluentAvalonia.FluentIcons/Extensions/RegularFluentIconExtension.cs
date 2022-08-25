using Avalonia.Markup.Xaml;

namespace FluentAvalonia.FluentIcons;

public class RegularFluentIconExtension : MarkupExtension
{
    private readonly RegularFluentIconSymbol _icon;

    public RegularFluentIconExtension(RegularFluentIconSymbol icon)
    {
        _icon = icon;
    }

    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        return new RegularFluentIcon
        {
            Icon = _icon
        };
    }
}