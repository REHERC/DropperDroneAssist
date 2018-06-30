using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Events;
using Spectrum.API.Interfaces.Plugins;
using Spectrum.API.Interfaces.Systems;
using Spectrum.API;
using Spectrum.API.IPC;
using Spectrum.Interop;
using Spectrum.Interop.Game;
using Spectrum.Interop.Helpers;
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
                    if (data.dropperIndex_ == 0)
                    {
                        Spectrum.Interop.Game.Vehicle.LocalVehicle.HUD.SetHUDText(CurrentPlugin.TryGetValue("JumpMessage", "JUMP !"));
                    }
                    else
                    { 
                        Spectrum.Interop.Game.Vehicle.LocalVehicle.HUD.SetHUDText(CurrentPlugin.TryGetValue("AvoidMesssage","AVOID !"));
                    }
                    break;
            }
        }
    }
}
