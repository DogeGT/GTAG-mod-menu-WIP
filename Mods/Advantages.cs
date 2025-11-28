using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine.InputSystem;

namespace StupidTemplate.Mods
{
    internal class Advantages
    {
        public static void GhostMonkie()
        {
            if (ControllerInputPoller.instance.rightControllerPrimaryButton || Mouse.current.rightButton.isPressed)
            {
                GorillaTagger.Instance.offlineVRRig.enabled = false;
            }

            else
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
            }
        }
    }
}
