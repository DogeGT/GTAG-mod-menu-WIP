using StupidTemplate.Classes;
using UnityEngine;

namespace StupidTemplate
{
    public class Settings
    {
        public static ExtGradient backgroundColor = new ExtGradient { rainbow = true };
        public static ExtGradient[] buttonColors = new ExtGradient[]
        {
            new ExtGradient { colors = ExtGradient.GetSimpleGradient(Color.black, Color.yellow) },
            new ExtGradient { rainbow = false } // Enabled
        };
        public static Color[] textColors = new Color[]
        {
            Color.white, // Disabled
            Color.white // Enabled
        };

        public static Font currentFont = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;

        public static bool fpsCounter = true;
        public static bool disconnectButton = true;
        public static bool rightHanded;
        public static bool disableNotifications;

        public static KeyCode keyboardButton = KeyCode.Q;

        public static Vector3 menuSize = new Vector3(0.1f, 1f, 1f);
        public static int buttonsPerPage = 8;

        public static float gradientSpeed = 0.5f; // Speed of colors
    }
}
