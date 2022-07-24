using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : Seeable 
{
    [Tooltip("The color the incoming light is multiplied by")]
    public Color reflectedColor = Color.white;
    private Color colorToReflect;
    /// <summary>
    /// Converts the incoming color to the outgoing color
    /// </summary>
    /// <param name="inColor"></param>
    /// <returns></returns>
    public Color ReflectColor(Color inColor)
    {
        inColor.a  = 1;
        reflectedColor.a = 1;
        //print(inColor);
        //print(reflectedColor);
        return reflectedColor * inColor;
    }
   
}
