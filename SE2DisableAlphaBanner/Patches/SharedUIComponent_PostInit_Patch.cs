using HarmonyLib;
using Keen.Game2.Client.UI.Library;
using System.Reflection;
using System.Reflection.Emit;

namespace SE2DisableAlphaBanner.Patches
{
    [HarmonyPatch(typeof(SharedUIComponent), "PostInit")]
    internal class SharedUIComponent_PostInit_Patch
    {
        private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            var il = instructions.ToList();

            int foundIndex = il.FindIndex(i => i.opcode == OpCodes.Call && (i.operand as MethodInfo).Name == "InitializeWatermarkScreen");

            il.RemoveRange(foundIndex - 1, 2);
            return il;
        }
    }
}
