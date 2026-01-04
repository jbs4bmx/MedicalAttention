using SPTarkov.Server.Core.Models.Eft.Common.Tables;
using SPTarkov.Server.Core.Models.Spt.Config;

namespace MedicalAttentionServer.Helpers;

public static class ItemResizeHelper
{
    public static void ResizeItem(TemplateItem item, ItemConfig itemConfig, string size)
    {
        if (item is null || item.Properties is null)
            return;

        var parts = size.Split('x');
        if (parts.Length != 2)
            return;

        if (int.TryParse(parts[0], out int width) &&
            int.TryParse(parts[1], out int height))
        {
            item.Properties.Width = width;
            item.Properties.Height = height;
        }
    }
}