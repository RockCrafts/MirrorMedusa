using UnityEngine;

[CreateAssetMenu(fileName = "StringVariable", menuName = "Variable/String Variable")]
public class StringVariable : ScriptableObject
{
#if UNITY_EDITOR
    [Multiline]
    public string DeveloperDescription = "";
#endif
    public string value = "";
    public string Value
    {
        get { return value; }
        set { this.value = value; }
    }
}
