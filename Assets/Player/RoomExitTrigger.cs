using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomExitTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {   
       if(other.TryGetComponent(out PlayerMovement player))
        {
            print("Player entered room exit trigger, Level is completed");

        }
    }
}
