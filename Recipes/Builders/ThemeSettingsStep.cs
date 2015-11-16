using System.Linq;
using System.Xml.Linq;
using IDeliverable.ThemeSettings.Services;
using Orchard.Environment.Extensions;
using Orchard.Localization;
using Orchard.Recipes.Services;

namespace IDeliverable.ThemeSettings.Recipes.Builders
{
    [OrchardFeature("IDeliverable.ThemeSettings.ImportExport")]
    public class ThemeSettingsStep : RecipeBuilderStep
    {
        private readonly IThemeSettingsService mThemeSettingsService;

        public ThemeSettingsStep(IThemeSettingsService themeSettingsService)
        {
            mThemeSettingsService = themeSettingsService;
        }

        public override string Name => "ThemeSettings";
        public override LocalizedString DisplayName => T("Theme Settings");
        public override LocalizedString Description => T("Exports Theme Settings.");

        public override void Build(BuildContext context)
        {
            var themes = mThemeSettingsService.GetAllProfiles().ToLookup(x => x.Theme);

            if (!themes.Any())
            {
                return;
            }

            var root = new XElement("ThemeSettings");
            context.RecipeDocument.Element("Orchard").Add(root);

            foreach (var theme in themes)
            {
                root.Add(new XElement("Theme",
                    new XAttribute("Name", theme.Key),
                    theme.Select(profile => new XElement("Profile",
                        new XAttribute("Name", profile.Name),
                        new XAttribute("Description", profile.Description ?? ""),
                        new XAttribute("IsCurrent", profile.IsCurrent),
                        new XCData(mThemeSettingsService.SerializeSettings(profile.Settings))))));
            }
        }
    }
}