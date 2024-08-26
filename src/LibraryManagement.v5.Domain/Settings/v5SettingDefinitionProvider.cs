using Volo.Abp.Settings;

namespace LibraryManagement.v5.Settings;

public class v5SettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(v5Settings.MySetting1));
    }
}
