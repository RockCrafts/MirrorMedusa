using UnityEngine;

public class ColorDoor : Door
{
    public Color keyColor;
    public Vector4 tolerance = new Vector4(0.1f, 0.1f, 0.1f, 1);

    public void CheckAndOpen(Color c)
    {
        if (VerifyColor(c))
        {
            Open = true;
        }
    }
    public bool VerifyColor(Color c)
    {
        for (int i = 0; i < 4; i++)
        {
            if (Mathf.Abs(keyColor[i] - c[i]) > tolerance[i]) return false;
        }
        return true;
    }
}
