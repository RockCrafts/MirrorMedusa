using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject moved;
    [Tooltip("The local position the moved object is moved to when the door opens")]
    public Vector2 openPos = new Vector2(0, 2);
    public float openSpeed = 2;
    private float lerp;

    private void FixedUpdate()
    {
        lerp = Mathf.MoveTowards(lerp, Open ? 1 : 0, Time.fixedDeltaTime * openSpeed);
        moved.transform.localPosition = Vector2.Lerp(Vector2.zero, openPos, lerp);
    }
    public bool Open
    {
        get; set;
    }
    public void ToggleOpen()
    {
        Open = !Open;
    }
}
