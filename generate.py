import re
import os
import shutil

def snake_to_pascal(str):
    return str.replace("_", " ").title().replace(" ", "")

def read_icons(json, dict):
    file = open(json, "r")
    lines = file.readlines()[1:-1]
    file.close()

    for line in lines:
        match = re.search(r"\"ic_fluent_(.+)_(\d+)_(filled|regular)\": (\d+)", line)
        dict[snake_to_pascal(f"{match[1]}{match[2]}")] = match[4]

regular_icons = {}
filled_icons = {}

read_icons("fluentui-system-icons/fonts/FluentSystemIcons-Regular.json", regular_icons)
read_icons("fluentui-system-icons/fonts/FluentSystemIcons-Filled.json", filled_icons)

new_line = "\n"

f = open("FluentAvalonia.FluentIcons/Enums/RegularFluentIconSymbol.cs", "w")
f.write(f"""// This file has been automatically generated by generate.py

namespace FluentAvalonia.FluentIcons;

[Obsolete("Use FluentIconSymbol instead. This will be removed when FluentAvalonia 2.0 is released.")]
public enum RegularFluentIconSymbol
{{
{new_line.join(["    {0} = {1},".format(key, value) for (key, value) in regular_icons.items()])}
}}
""")
f.close()

f = open("FluentAvalonia.FluentIcons/Enums/FilledFluentIconSymbol.cs", "w")
f.write(f"""// This file has been automatically generated by generate.py

namespace FluentAvalonia.FluentIcons;

[Obsolete("Use FluentIconSymbol instead. This will be removed when FluentAvalonia 2.0 is released.")]
public enum FilledFluentIconSymbol
{{
{new_line.join(["    {0} = {1},".format(key, value) for (key, value) in filled_icons.items()])}
}}
""")
f.close()

f = open("FluentAvalonia.FluentIcons/Enums/FluentIconSymbol.cs", "w")
f.write(f"""// This file has been automatically generated by generate.py

namespace FluentAvalonia.FluentIcons;

public enum FluentIconSymbol
{{
{new_line.join(["    {0}Filled = {1},".format(key, int(value) * 100) for (key, value) in filled_icons.items()])}
{new_line.join(["    {0}Regular = {1},".format(key, value) for (key, value) in regular_icons.items()])}
}}

""")
f.close()

base_path = os.path.dirname(os.path.realpath(__file__))
shutil.copyfile(os.path.join(base_path, "fluentui-system-icons/fonts/FluentSystemIcons-Regular.ttf"),
                os.path.join(base_path, "FluentAvalonia.FluentIcons/Resources/FluentSystemIcons-Regular.ttf"))
shutil.copyfile(os.path.join(base_path, "fluentui-system-icons/fonts/FluentSystemIcons-Filled.ttf"),
                os.path.join(base_path, "FluentAvalonia.FluentIcons/Resources/FluentSystemIcons-Filled.ttf"))