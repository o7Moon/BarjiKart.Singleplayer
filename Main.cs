using MelonLoader;
using HarmonyLib;
using UnityEngine;
using UnityEngine.SceneManagement;
using Il2CppSystem;

[assembly: MelonInfo(typeof(BarjiKart.Singleplayer.SingleplayerMod), "BarjiKart.Singleplayer","1.0.0","o7Moon")]
namespace BarjiKart.Singleplayer {
    [HarmonyPatch]
    public class SingleplayerMod : MelonMod
    {
        [HarmonyPatch(typeof(Barji.TrackSelectionManager),nameof(Barji.TrackSelectionManager.UpdateTrackSelectionGraphic))]
        [HarmonyPostfix]
        public static void onTrackSelect(Barji.TrackSelectionManager __instance, ushort __0, short __1, int __2){
            if (Input.GetKey(KeyCode.LeftShift)) SceneManager.LoadScene(__1);
        }
    }
}
