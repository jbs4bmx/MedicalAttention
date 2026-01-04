using SPTarkov.Server.Core.Models.Eft.Common.Tables;

namespace MedicalAttentionServer.Helpers;

public static class SplintHelper
{
    /// <summary>
    /// Apply the base splint settings shared by the standard Splint and Aluminum Splint.
    /// </summary>
    public static void ApplyBaseSplintSettings(
        TemplateItem item,
        dynamic configSection)
    {
        item.Properties!.MaxHpResource = configSection.hpResource;
        item.Properties!.MedUseTime = 1;
    }
}
