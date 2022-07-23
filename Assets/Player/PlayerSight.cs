using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSight : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sightCheck(gameObject.transform.position, gameObject.transform.up);
    }
    void sightCheck(Vector2 origin, Vector2 angle)
    {
        //cast the ray
        RaycastHit2D hit = Physics2D.Raycast(origin, angle);

        Debug.DrawRay(transform.position, transform.up * 100f, Color.red);
        //Check for self-hit
        if (hit.collider.gameObject.CompareTag("Player"))
        {
            //die
        }

        //ideally we check if its a mirror here
        if (hit.collider.gameObject.GetComponent<Mirror>() != null)
        {
            //recursive?
            sightCheck(hit.point, hit.normal);
        }


    }
}
