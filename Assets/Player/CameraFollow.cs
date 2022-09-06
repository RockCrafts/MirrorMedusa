using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // dummy comment to force out of date local repo, ignore
    public GameObject player;
    float z;
    void Awake() {
        float z = transform.position.z;
    }
   void LateUpdate() {
    transform.position = new Vector3(player.transform.position.x, 0, -10);
   }
}
