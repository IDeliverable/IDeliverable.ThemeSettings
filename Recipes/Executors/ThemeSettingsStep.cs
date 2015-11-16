using IDeliverable.ThemeSettings.Models;
using IDeliverable.ThemeSettings.Services;
using Orchard.ContentManagement;
using Orchard.Environment.Extensions;
using Orchard.Recipes.Models;
using Orchard.Recipes.Services;

namespace IDeliverable.ThemeSettings.Recipes.Executors
{
    [OrchardFeature("IDeliverable.ThemeSettings.ImportExport")]
    public class ThemeSettingsStep : RecipeExecutionStep
    {
        private readonly IThemeSettingsService _themeSettingsService;
        public ThemeSettingsStep(IThemeSettingsService themeSettingsService, RecipeExecutionLogger logger) : base(logger)
        {
            _themeSettingsService = themeSettingsService;
        }

        public override string Name => "ThemeSettings";
        
        public override void Execute(RecipeExecutionContext context)
        {
            foreach (var themeElement in context.RecipeStep.Step.Elements())
            {
                var themeName = themeElement.Attr<string>("Name");

                foreach (var profileElement in themeElement.Elements()) {
                    var profileName = profileElement.Attr<string>("Name");
                    var profile = _themeSettingsService.GetProfile(profileName) ?? new ThemeProfile();

                    profile.Name = profileElement.Attr<string>("Name");
                    profile.Description = profileElement.Attr<string>("Description");
                    profile.Theme = themeName;
                    profile.IsCurrent = profileElement.Attr<bool>("IsCurrent");
                    profile.Settings = _themeSettingsService.DeserializeSettings(profileElement.Value);

                    _themeSettingsService.SaveProfile(profile);
                }
            }
        }
    }
}
