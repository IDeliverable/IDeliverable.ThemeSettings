# IDeliverable.ThemeSettings

IDeliverable.ThemeSettings is a module for the Orchard CMS that provides functionality to enable themes to expose settings that are configurable by site owners in the admin UI.

## Features

### Theme Settings

Provides functionality to enable themes to expose settings that are configurable by site owners in the admin UI. Themes can expose a *theme settings manifest* containing a description of the configurable settings exposed by the theme. **IDeliverable.ThemeSettings** will parse this manifest and expose the declared settings in the Orchard admin UI for site owners to configure. 

To provide theme settings from your theme, follow the following steps:

1. Create a file named `Settings.json` in the root folder of your theme (or copy `Settings.json.sample` from this project and rename to `Settings.json`) This file is the theme's *theme settings manifest*.
1. Update the `Settings.json` file with your theme-specific settings.
1. To acess configured settings in your theme at runtime, see the sample Razor view `ThemeSettings.cshtml.sample` which demonstrates a typical use case where an inline style is rendered in the `<head>` section of the document leveraging the configured theme settings.

### Theme Settings Import/Export

Provides support for import and export of theme settings.

## Compatibility

This module is compatible with **Orchard version 1.10.x**. The module might also work on older or newer versions of Orchard but this is not guaranteed.

## License

This module is open source and free for use under the permissive [MIT license](https://opensource.org/licenses/MIT), which means you are free to change it, redistribute it and generally use it in whatever way you want.