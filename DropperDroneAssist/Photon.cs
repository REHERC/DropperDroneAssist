using Events;
using Spectrum.API.Interfaces.Plugins;
using Spectrum.API.Interfaces.Systems;
using UnityEngine;

namespace DropperDroneAssist
{
    public class Photon : IPlugin
    {
        public void Initialize(IManager manager, string ipcIdentifier)
        {
            CurrentPlugin.Initialize();
            Events.DropperDroneStateChange.SubscribeAll(DropperDroneStateChange_EventHandler);
        }

        private void DropperDroneStateChange_EventHandler(GameObject sender, DropperDroneStateChange.Data data)
        {
            switch (data.state_)
            {
                case VirusDropperDroneLogic.State.Chase:
                    Spectrum.Interop.Game.Vehicle.LocalVehicle.HUD.SetHUDText(CurrentPlugin.TryGetValue("WarningMessage", "WARNING: DRONE CHASING !"));
                    break;
                case VirusDropperDroneLogic.State.StompWarning:
                        Spectrum.Interop.Game.Vehicle.LocalVehicle.HUD.SetHUDText(CurrentPlugin.TryGetValue("AvoidMessage", "AVOID !"));
                    break;
            }
        }
    }
}
