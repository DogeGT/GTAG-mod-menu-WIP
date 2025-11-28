using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using static StupidTemplate.Menu.Main;

namespace StupidTemplate.Mods
{
    internal class Fun
    {
        public static GameObject Blockscube;
        public static void CreateBlocks() {
            if (ControllerInputPoller.instance.rightGrab)
            {
                if (Blockscube == null) {
                    Blockscube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    Blockscube.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
                }

                else {
                    Blockscube.transform.position = TrueRightHand().position;
                    Blockscube.transform.rotation = TrueRightHand().rotation;
                }
            }

            else {
                Blockscube = null;
            }
        }
    }
}
