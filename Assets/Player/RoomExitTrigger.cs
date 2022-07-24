using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomExitTrigger : MonoBehaviour
{

    [SerializeField] GameEvent levelCompleted;
    private void OnTriggerEnter2D(Collider2D other)
    {   
       if(other.TryGetComponent(out PlayerMovement player))
        {
            levelCompleted.Invoke();

        }
    }
}
