using Keen.Game2.Game.Plugins;
using Keen.VRage.Library.Diagnostics;
using HarmonyLib;
using System.Reflection;

namespace SE2DisableAlphaBanner
{
    public class Plugin : IPlugin
    {
        public const string Name = "SE2DisableAlphaBanner";

        public Plugin()
        {
            Log.Default.WriteLine($"[{Name}] Loaded plugin.");

            Harmony harmony = new Harmony(Name);
            harmony.PatchAll(Assembly.GetExecutingAssembly());

            Log.Default.WriteLine($"[{Name}] Applied patches");
        }
    }
}
