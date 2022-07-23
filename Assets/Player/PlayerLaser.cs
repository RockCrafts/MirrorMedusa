using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaser : MonoBehaviour
{
    RaycastHit2D hit;
    public LineRenderer line;
    private float range = 100f;
    private void Update() {

        hit = Physics2D.Raycast(transform.position, transform.up, range);
        line.SetPositions(new Vector3[]{transform.position, transform.up * range});
        
        

    }
}
