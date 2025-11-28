using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine.InputSystem;
using StupidTemplate.Classes;
using UnityEngine;

namespace StupidTemplate.Mods
{
    internal class Advantages
    {
        public static void GhostMonkie()
        {
            if (ControllerInputPoller.instance.rightControllerPrimaryButton || Mouse.current.rightButton.isPressed) {
                GorillaTagger.Instance.offlineVRRig.enabled = false;
                HandManager.RigRenderHands();
            }

            else {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
                HandManager.stopRigRenderHands();
            }
        }

        public static void GhostMonkiedisable()
        {
            GorillaTagger.Instance.offlineVRRig.enabled = true;
            HandManager.stopRigRenderHands();
        }

        public static void invisMonkie()
        {
            if (ControllerInputPoller.instance.rightControllerPrimaryButton || Mouse.current.rightButton.isPressed)
            {
                GorillaTagger.Instance.offlineVRRig.enabled = false;
                VRRig.LocalRig.transform.position = GorillaTagger.Instance.bodyCollider.transform.position - Vector3.up * 99999f;
                HandManager.RigRenderHands();
            }

            else
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
                HandManager.stopRigRenderHands();
            }
        }

        public static void invisMonkiedisable()
        {
            GorillaTagger.Instance.offlineVRRig.enabled = true;
            HandManager.stopRigRenderHands();
        }
    }
}
