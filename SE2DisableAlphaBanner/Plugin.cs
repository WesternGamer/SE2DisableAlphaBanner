using Keen.Game2.Game.Plugins;
using Keen.VRage;
using Keen.VRage.Library.Diagnostics;
using Keen.VRage.Core.EngineComponents;
using Keen.VRage.DCS;
using Keen.VRage.DCS.Components;
using Keen.VRage.Core;
using Keen.VRage.Core.Project;
using HarmonyLib;
using System.Reflection;
using System.Xml.Linq;
using Keen.Game2.Client.RuntimeSystems.CoreScenes;

namespace SE2DisableAlphaBanner
{
    public class Plugin : IPlugin, IDisposable
    {
        public const string Name = "ClientPluginTemplate";
        public static Plugin Instance { get; private set; }

        public Plugin(PluginHost host)
        {
            Instance = this;

            Log.Default.WriteLine($"[Test Plugin] Loaded test plugin");

            host.OnBeforeEngineInstantiated += Host_OnBeforeEngineInstantiated;
            host.OnBeforeProjectsLoaded += Host_OnBeforeProjectsLoaded;
        }

        private void Host_OnBeforeEngineInstantiated(EngineBuilder builder)
        {
            builder.Configure<GameRenderComponentCoreConfigurationObjectBuilder>().DrawAlphaBanner = false;
        }

        private void Host_OnBeforeProjectsLoaded(List<VRageProject> list)
        {
            //Harmony harmony = new Harmony(Name);
            //harmony.PatchAll(Assembly.GetExecutingAssembly());
        }

        public void Dispose()
        {
            Instance = null;
        }
    }
}
