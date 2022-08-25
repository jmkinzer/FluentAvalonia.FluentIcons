# FluentAvalonia.FluentIcons
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
                    <ic:FilledFluentIcon Icon="Settings16"/>
                </ui:NavigationViewItem.Icon>
            </ui:NavigationViewItem>

            <!-- The library also provides markup extensions to reduce boilerplate code -->
            <ui:NavigationViewItem Content="Page 2"
                                   Icon="{ic:RegularFluentIcon Settings16}"/>
        </ui:NavigationView.MenuItems>
    </ui:NavigationView>
</Window>
```