using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaser : MonoBehaviour
{
    RaycastHit2D hit;
    public LineRenderer line;
    private float range = 100f;
    private void Update() {
       //Layermask
       LayerMask mask = LayerMask.GetMask("Default");
        hit = Physics2D.Raycast(transform.position, transform.up, 100, mask);
        if(hit)
            line.SetPositions(new Vector3[]{transform.position, hit.point});
        
        else
            line.SetPositions(new Vector3[]{transform.position, transform.up * range});
        
        

    }
}
