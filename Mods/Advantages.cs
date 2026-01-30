using UnityEngine;
using UnityEngine.InputSystem;
using StupidTemplate.Classes;

namespace StupidTemplate.Mods
{
    internal class Advantages
    {
        public static bool AWasPress = false;
        public static bool GM_Last = false;

        public static void GhostMonkie()
        {
            bool pressedGM = ControllerInputPoller.instance.rightControllerSecondaryButton
                             || Mouse.current.rightButton.isPressed;


            if (pressedGM && !GM_Last)
            {
                AWasPress = !AWasPress;
            }

            GM_Last = pressedGM;

            if (AWasPress)
            {
                GorillaTagger.Instance.offlineVRRig.enabled = false;
                HandManager.RigRenderHands();
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
                HandManager.stopRigRenderHands();
            }
        }

        public static void GhostMonkiedisable()
        {
            AWasPress = false;
            GorillaTagger.Instance.offlineVRRig.enabled = true;
            HandManager.stopRigRenderHands();
        }

        public static bool BWasPress = false;
        public static bool IM_Last = false;

        public static void InvisMonkie()
        {
            bool pressedIM = ControllerInputPoller.instance.rightControllerPrimaryButton
                             || Mouse.current.leftButton.isPressed;

            if (pressedIM && !IM_Last)
            {
                BWasPress = !BWasPress;
            }

            IM_Last = pressedIM;

            if (BWasPress)
            {
                GorillaTagger.Instance.offlineVRRig.enabled = false;
                VRRig.LocalRig.transform.position =
                GorillaTagger.Instance.bodyCollider.transform.position - Vector3.up * 99999f;
                HandManager.RigRenderHands();
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
                HandManager.stopRigRenderHands();
            }
        }

        public static void InvisMonkiedisable()
        {
            BWasPress = false;
            GorillaTagger.Instance.offlineVRRig.enabled = true;
            HandManager.stopRigRenderHands();
        }
    }
}
