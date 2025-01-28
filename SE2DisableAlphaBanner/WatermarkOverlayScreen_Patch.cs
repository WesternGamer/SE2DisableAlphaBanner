using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Keen.Game2.Client.UI.Overlays;

namespace SE2DisableAlphaBanner
{
    [HarmonyPatch(typeof(WatermarkOverlayScreen), MethodType.Constructor)]
    internal class WatermarkOverlayScreen_Patch
    {
        private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            var il = instructions.ToList();
            il.RemoveRange(2, 3);

            return il;
        }
    }
}
