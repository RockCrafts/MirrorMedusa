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
    //Get Sprite Renderer
    private SpriteRenderer spriteRenderer;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = reflectedColor;
    }
 
    public Color ReflectColor(Color inColor)
    {
        inColor.a  = 1;
        reflectedColor.a = 1;

        print("REFLECTED: "+ gameObject.name + " " + reflectedColor * inColor);

        return reflectedColor * inColor;
    }
   
}
