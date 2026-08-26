using SPTarkov.Server.Core.Helpers.Server;
using SPTarkov.Server.Core.Models.Eft.Common.Tables;
using SPTarkov.Server.Core.Models.Spt.Tables;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace MedicalAttentionServer.Helpers;

public static class BuffHelper
{
    /// <summary>
    /// Registers a buff with the server and assigns it to the item.
    /// </summary>
    public static void ApplyBuff(TemplateItem item, string buffId, TemplateTable templateTable, GlobalTable globalTable)
    {
        PushBuff(buffId, templateTable, globalTable);
        item.Properties!.StimulatorBuffs = buffId;
    }

    /// <summary>
    /// Loads buff data from BuffGlobals.json and registers it into the SPT globals table.
    /// </summary>
    private static void PushBuff(string buffName, TemplateTable templateTable, GlobalTable globalTable)
    {
        // Locate BuffGlobals.json inside the mod folder
        var modPath = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;
        var buffFilePath = System.IO.Path.Combine(modPath, "BuffGlobals.json");

        // Load and parse the JSON
        var buffJson = File.ReadAllText(buffFilePath);
        var buffNode =
            (JsonNode.Parse(buffJson)?["buffs"]?[buffName])
            ?? throw new InvalidOperationException($"Buff '{buffName}' not found in BuffGlobals.json");

        // Access SPT globals → Health → Effects → Stimulator → Buffs
        var stimulator = globalTable?.Configuration?.Health?.Effects?.Stimulator;
        var buffs = stimulator?.Buffs;

        // Register buff only if not already present
        if (buffs != null && !buffs.ContainsKey(buffName))
        {
            var buffData = JsonSerializer.Deserialize<List<Buff>>(buffNode.ToJsonString());
            buffs.Add(buffName, buffData!);
        }
    }
}
