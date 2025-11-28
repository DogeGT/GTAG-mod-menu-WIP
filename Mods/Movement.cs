using GorillaLocomotion;
using StupidTemplate.Classes;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using static StupidTemplate.Menu.Main;
using static StupidTemplate.Mods.Settings.Movement;

namespace StupidTemplate.Mods
{
    public class Movement
    {
        public static void Fly()
        {
            if (ControllerInputPoller.instance.rightControllerPrimaryButton)
            {
                GTPlayer.Instance.transform.position += GorillaTagger.Instance.headCollider.transform.forward * Time.deltaTime * Settings.Movement.flySpeed;
                GorillaTagger.Instance.rigidbody.linearVelocity = Vector3.zero;
            }
        }

        public static GameObject platl;
        public static GameObject platr;

        public static bool leftWasGrab = false;
        public static bool rightWasGrab = false;

        public static void Platforms()
        {
            if (ControllerInputPoller.instance.leftGrab && !leftWasGrab)
            {
                if (platl == null)
                {
                    platl = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    platl.transform.localScale = new Vector3(0.025f, 0.3f, 0.4f);
                    platl.transform.position = TrueLeftHand().position;
                    platl.transform.rotation = TrueLeftHand().rotation;

                    FixStickyColliders(platl);

                    ColorChanger colorChanger = platl.AddComponent<ColorChanger>();
                    colorChanger.colors = StupidTemplate.Settings.backgroundColor;
                }
            }
            if (!ControllerInputPoller.instance.leftGrab && leftWasGrab)
            {
                if (platl != null)
                {
                    Object.Destroy(platl);
                    platl = null;
                }
            }

            if (ControllerInputPoller.instance.rightGrab && !rightWasGrab)
            {
                if (platr == null)
                {
                    platr = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    platr.transform.localScale = new Vector3(0.025f, 0.3f, 0.4f);
                    platr.transform.position = TrueRightHand().position;
                    platr.transform.rotation = TrueRightHand().rotation;

                    FixStickyColliders(platr);

                    ColorChanger colorChanger = platr.AddComponent<ColorChanger>();
                    colorChanger.colors = StupidTemplate.Settings.backgroundColor;
                }
            }

            if (!ControllerInputPoller.instance.rightGrab && rightWasGrab) // grab released
            {
                if (platr != null)
                {
                    Object.Destroy(platr);
                    platr = null;
                }
            }

            leftWasGrab = ControllerInputPoller.instance.leftGrab;
            rightWasGrab = ControllerInputPoller.instance.rightGrab;
        }

        public static bool previousTeleportTrigger;
        public static void TeleportGun()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                var GunData = RenderGun();
                GameObject NewPointer = GunData.NewPointer;

                if (ControllerInputPoller.TriggerFloat(XRNode.RightHand) > 0.5f && !previousTeleportTrigger)
                {
                    GTPlayer.Instance.TeleportTo(NewPointer.transform.position + Vector3.up, GTPlayer.Instance.transform.rotation);
                    GorillaTagger.Instance.rigidbody.linearVelocity = Vector3.zero;
                }

                previousTeleportTrigger = ControllerInputPoller.TriggerFloat(XRNode.RightHand) > 0.5f;
            }
        }

        public static void WASDFLY()
        {
            bool isMoving;

            isMoving =
            Keyboard.current.wKey.isPressed ||
            Keyboard.current.aKey.isPressed ||
            Keyboard.current.sKey.isPressed ||
            Keyboard.current.dKey.isPressed ||
            Keyboard.current.spaceKey.isPressed ||
            Keyboard.current.leftCtrlKey.isPressed;

            Rigidbody rb = GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>();

            Vector3 moveDir = Vector3.zero;

            // Forward
            if (Keyboard.current.wKey.isPressed)
                moveDir += GorillaLocomotion.GTPlayer.Instance.headCollider.transform.forward;

            // Backward
            if (Keyboard.current.sKey.isPressed)
                moveDir -= GorillaLocomotion.GTPlayer.Instance.headCollider.transform.forward;

            // Right
            if (Keyboard.current.dKey.isPressed)
                moveDir += GorillaLocomotion.GTPlayer.Instance.headCollider.transform.parent.right;

            // Left
            if (Keyboard.current.aKey.isPressed)
                moveDir -= GorillaLocomotion.GTPlayer.Instance.headCollider.transform.parent.right;

            // Up
            if (Keyboard.current.spaceKey.isPressed)
                moveDir += GorillaLocomotion.GTPlayer.Instance.headCollider.transform.up;

            // Down
            if (Keyboard.current.ctrlKey.isPressed)
                moveDir -= GorillaLocomotion.GTPlayer.Instance.headCollider.transform.up;

            if (!isMoving)
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;

            // Apply movement
            if (moveDir != Vector3.zero)
            {
                GorillaLocomotion.GTPlayer.Instance.transform.position += moveDir * Settings.Movement.flySpeed * Time.deltaTime;

                // Zero velocity (new Unity API)
                rb.linearVelocity = Vector3.zero;
            }

        }

        public static void speedboost() {
            GorillaLocomotion.GTPlayer.Instance.jumpMultiplier = speedBoostSpeed;
            GorillaLocomotion.GTPlayer.Instance.maxJumpSpeed = speedBoostSpeed;
        }
    }
}
