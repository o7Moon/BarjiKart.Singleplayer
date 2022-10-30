using BepInEx;
using BepInEx.IL2CPP;
using HarmonyLib;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace singeplayerMod
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BasePlugin
    {
        public override void Load()
        {
            // Plugin startup logic
            Harmony.CreateAndPatchAll(typeof(Plugin));
            Log.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
        }
        [HarmonyPatch(typeof(Barji.TrackSelectionGraphic),nameof(Barji.TrackSelectionGraphic.UpdateDetails))]
        [HarmonyPostfix]
        public static void OnTrackSelected(Barji.TrackSelectionGraphic __instance, ushort __0, MHILKHJNBHF __1, int __2){
            if (Input.GetKey(KeyCode.LeftShift)){
                int scene_num = (int) __1;
                SceneManager.LoadScene(scene_num);
            }
        }
    }
}
