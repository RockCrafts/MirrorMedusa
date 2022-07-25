using UnityEngine;
using UnityEngine.Events;

public class Detector2D : MonoBehaviour
{
    public LayerMask layerMask;
    public UnityEvent<Collider2D> enter;
    public UnityEvent<Collider2D> stay;
    public UnityEvent<Collider2D> exit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (layerMask.value == (layerMask.value | (1 << collision.gameObject.layer)))
            enter.Invoke(collision);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (layerMask.value == (layerMask.value | (1 << collision.gameObject.layer)))
            stay.Invoke(collision);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (layerMask.value == (layerMask.value | (1 << collision.gameObject.layer)))
            exit.Invoke(collision);
    }
}
