using BepInEx;
using BepInEx.Logging;
using Console;
using UnityEngine;
using static StupidTemplate.Menu.Main;


namespace StupidTemplate
{
    [System.ComponentModel.Description(PluginInfo.Description)]
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class HarmonyPatches : BaseUnityPlugin
    {
        private void Awake() =>
            GorillaTagger.OnPlayerSpawned(OnPlayerSpawned);

        void Start() =>
            GorillaTagger.OnPlayerSpawned(OnPlayerSpawned);

        public void OnPlayerSpawned() =>
            Patches.PatchHandler.PatchAll();
    }
}
