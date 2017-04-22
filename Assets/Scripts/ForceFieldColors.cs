using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RUF
{
    public struct ForceFieldColors
    {
        public enum Values
        {
            Cyan,
            Purple,
            Yellow
        }

        public static Color ConvertToColor(Values ffColor)
        {
            if (ffColor == Values.Cyan)
            {
                return new Color(0.75f, 1, 1, 0.5f);
            }
            if (ffColor == Values.Purple)
            {
                return new Color(0.8f, 0.45f, 0.8f, 0.5f);
            }
            if (ffColor == Values.Yellow)
            {
                return new Color(1, 1, 0, 0.5f);
            }
            return new Color(0, 0, 0, 0.5f);
        }

        public static int ConvertToPhysicsLayer(Values ffColor)
        {
            if (ffColor == Values.Yellow)
            {
                return 8;
            }
            if (ffColor == Values.Cyan)
            {
                return 9;
            }
            if (ffColor == Values.Purple)
            {
                return 10;
            }
            return 0;
        }

        public static int ConvertToPlayerPhysicsLayer(Values ffColor)
        {
            if (ffColor == Values.Yellow)
            {
                return 11;
            }
            if (ffColor == Values.Cyan)
            {
                return 12;
            }
            if (ffColor == Values.Purple)
            {
                return 13;
            }
            return 0;
        }
    }
}