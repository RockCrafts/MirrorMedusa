using UnityEngine;

[CreateAssetMenu(fileName = "Vec4Variable", menuName = "Variable/Vec4 Variable")]
public class Vec4Variable : ScriptableObject
{
#if UNITY_EDITOR
    [Multiline]
    public string DeveloperDescription = "";
#endif
    public Vector4 Value;

    public void SetValue(Vector4 value)
    {
        Value = value;
    }

    public void SetValue(Vec4Variable value)
    {
        Value = value.Value;
    }

    public void ApplyChange(Vector4 amount)
    {
        Value += amount;
    }

    public void ApplyChange(Vec4Variable amount)
    {
        Value += amount.Value;
    }
}