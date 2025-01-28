using HarmonyLib;
using Keen.Game2.Client.UI.Library;
using System.Reflection;
using System.Reflection.Emit;

namespace SE2DisableAlphaBanner.Patches
{
    [HarmonyPatch(typeof(SharedUIComponent), "SetOverlayVisibility")]
    internal class SharedUIComponent_SetOverlayVisibility_Patch
    {
        private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            var il = instructions.ToList();

            int foundIndex = il.FindIndex(i => i.opcode == OpCodes.Ldfld && (i.operand as FieldInfo).Name == "_watermarkOverlayVm");

            il.RemoveRange(foundIndex - 1, 27);

            il.Insert(foundIndex - 1, new CodeInstruction(OpCodes.Ldc_I4_0));
            il.Insert(foundIndex, new CodeInstruction(OpCodes.Ret));
            return il;
        }
    }
}
