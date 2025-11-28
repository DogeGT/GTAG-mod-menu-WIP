using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using static StupidTemplate.Menu.Main;
using static StupidTemplate.Settings;

namespace StupidTemplate.Classes
{
    internal class HandManager
    {
        public static GameObject lefthandcube;
        public static GameObject righthandcube;

        public static void  RigRenderHands() {
            if (righthandcube == null) {
                righthandcube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                righthandcube.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                GameObject.Destroy(righthandcube.GetComponent<Rigidbody>());
                GameObject.Destroy(righthandcube.GetComponent<BoxCollider>());
                righthandcube.GetComponent<Renderer>().material.color = backgroundColor.colors[0].color;

                righthandcube.transform.position = TrueRightHand().position;
                righthandcube.transform.rotation = TrueRightHand().rotation;
            }

            else {
                righthandcube.transform.position = TrueRightHand().position;
                righthandcube.transform.rotation = TrueRightHand().rotation;
            }

            if (lefthandcube == null) {
                lefthandcube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                lefthandcube.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                GameObject.Destroy(lefthandcube.GetComponent<Rigidbody>());
                GameObject.Destroy(lefthandcube.GetComponent<BoxCollider>());
                lefthandcube.GetComponent<Renderer>().material.color = backgroundColor.colors[0].color;

                lefthandcube.transform.position = TrueLeftHand().position;
                lefthandcube.transform.rotation = TrueLeftHand().rotation;
            }

            else {
                lefthandcube.transform.position = TrueLeftHand().position;
                lefthandcube.transform.rotation = TrueLeftHand().rotation;
            }
        }

        public static void stopRigRenderHands() {
            GameObject.Destroy(righthandcube);
            GameObject.Destroy(lefthandcube);

            lefthandcube = null;
            righthandcube = null;
        }
    }
}
