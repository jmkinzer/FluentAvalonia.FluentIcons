# FluentAvalonia.FluentIcons <a href="https://www.nuget.org/packages/FluentAvalonia.FluentIcons"><img alt="Version" src="https://img.shields.io/nuget/v/FluentAvalonia.FluentIcons"/></a> <a href="https://www.nuget.org/packages/FluentAvalonia.FluentIcons"><img src="https://img.shields.io/nuget/dt/FluentAvalonia.FluentIcons" alt="Download count"/></a> <img src="https://img.shields.io/badge/.NET-.NET%20Standard%202.0%20%7C%20.NET%206.0-informational" alt=".NET version"/>
FluentAvalonia.FluentIcons adds support for all [Fluent UI System Icons](https://github.com/microsoft/fluentui-system-icons) to [FluentAvalonia](https://github.com/amwx/FluentAvalonia).

This library is compatible with all FluentAvalonia controls.

# Usage
Include the namespace in your control.
```xaml
xmlns:ic="using:FluentAvalonia.FluentIcons"
```

# Example
```xaml
<Window xmlns="https://github.com/avaloniaui"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:ic="using:FluentAvalonia.FluentIcons"
        xmlns:ui="using:FluentAvalonia.UI.Controls"
        mc:Ignorable="d" d:DesignWidth="800" d:DesignHeight="450"
        x:Class="Avalonia.NETCoreApp1.MainWindow"
        Title="Avalonia.NETCoreApp1">
        
    <ui:NavigationView>
        <ui:NavigationView.MenuItems>
            <ui:NavigationViewItem Content="Page 1">
                <ui:NavigationViewItem.Icon>
                    <ic:FluentIcon Icon="Settings16Filled"/>
                </ui:NavigationViewItem.Icon>
            </ui:NavigationViewItem>

            <!-- The library also provides markup extensions to reduce boilerplate code -->
            <ui:NavigationViewItem Content="Page 2"
                                   Icon="{ic:FluentIcon Settings16Regular}"/>
        </ui:NavigationView.MenuItems>
    </ui:NavigationView>
</Window>
```

# Rendering
The current approach for rendering icons is to take the glyph from the regular/filled font, extract the SVG path and put it into a PathIcon.

The number in the ``FluentIconSymbol`` enum represents the size of the glyph in the font. It doesn't affect how big the icon will be (use the ``Width`` and ``Height`` properties for that), but it does affect how the icon is scaled, which is visible at lower sizes.

This is how the regular settings icon looks in NavigationView.

![image](https://user-images.githubusercontent.com/79316397/192348887-a3c14733-4072-4e3a-a1a1-b8975208e45e.png)

The resizable font has the same problem, but if an icon looks bad, you can't choose another size, because there's only one.

Using FontIcon is also not a good approach, as the icon is way too small and the scaling is different depending on the operating system. On Windows it looks normal, but on Linux it may look like this:

![image](https://user-images.githubusercontent.com/79316397/192355518-cf749f59-715f-4470-9641-dc225b2c709e.png)
