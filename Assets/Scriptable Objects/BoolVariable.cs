using UnityEngine;

[CreateAssetMenu(fileName = "BoolVariable", menuName = "Variable/Bool Variable")]
public class BoolVariable : ScriptableObject
{
#if UNITY_EDITOR
    [Multiline]
    public string DeveloperDescription = "";
#endif
    public bool value;
    public bool Value
    {
        get { return value; }
        set { this.value = value; }
    }
}
