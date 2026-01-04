using SPTarkov.Server.Core.Helpers;
using SPTarkov.Server.Core.Models.Eft.Common;
using SPTarkov.Server.Core.Models.Eft.Common.Tables;
using SPTarkov.Server.Core.Services;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Nodes;
using Path = System.IO.Path;

namespace MedicalAttentionServer.Helpers;

public static class BuffHelper
{
    /// <summary>
    /// Registers a buff with the server and assigns it to the item.
    /// </summary>
    public static void ApplyBuff(
        TemplateItem item,
        string buffId,
        DatabaseService databaseService,
        ModHelper modHelper)
    {
        PushBuff(buffId, databaseService, modHelper);
        item.Properties!.StimulatorBuffs = buffId;
    }

    /// <summary>
    /// Loads buff data from BuffGlobals.json and registers it into the SPT globals table.
    /// </summary>
    private static void PushBuff(
        string buffName,
        DatabaseService databaseService,
        ModHelper modHelper)
    {
        // Locate BuffGlobals.json inside the mod folder
        var modPath = modHelper.GetAbsolutePathToModFolder(Assembly.GetExecutingAssembly());
        var buffFilePath = Path.Combine(modPath, "BuffGlobals.json");

        // Load and parse the JSON
        var buffJson = File.ReadAllText(buffFilePath);
        var buffNode =
            (JsonNode.Parse(buffJson)?["buffs"]?[buffName])
            ?? throw new InvalidOperationException($"Buff '{buffName}' not found in BuffGlobals.json");

        // Access SPT globals → Health → Effects → Stimulator → Buffs
        var globals = databaseService.GetGlobals();
        var stimulator = globals?.Configuration?.Health?.Effects?.Stimulator;
        var buffs = stimulator?.Buffs;

        // Register buff only if not already present
        if (buffs != null && !buffs.ContainsKey(buffName))
        {
            var buffData = JsonSerializer.Deserialize<List<Buff>>(buffNode.ToJsonString());
            buffs.Add(buffName, buffData!);
        }
    }
}
