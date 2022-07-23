using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour
{
    [Tooltip("The color the incoming light is multiplied by")]
    public Color reflectedColor;

    /// <summary>
    /// Converts the incoming color to the outgoing color
    /// </summary>
    /// <param name="inColor"></param>
    /// <returns></returns>
    public Color ReflectColor(Color inColor)
    {
        return inColor * reflectedColor;
    }
}
