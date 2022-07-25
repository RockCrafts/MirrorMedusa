using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityDoor : Door
{
    private List<GameObject> nearMe = new List<GameObject>();
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.gameObject.name + " entered");
        nearMe.Add(collision.gameObject);
        Open = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        print(collision.gameObject.name + " exited");
        nearMe.Remove(collision.gameObject);
        if (nearMe.Count == 0) Open = false;
    }
}
