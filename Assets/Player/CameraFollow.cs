using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    float z;
    void Awake() {
        float z = transform.position.z;
    }
   void Update() {
    transform.position = new Vector3(player.transform.position.x, 0, -10);
   }
}
