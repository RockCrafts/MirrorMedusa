using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSight : MonoBehaviour
{
    // Start is called before the first frame update
    PlayerMovement pMove;
    void Start()
    {
        pMove = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        sightCheck(transform.position, pMove.visionAngle);
    }
    void sightCheck(Vector2 origin, Vector2 angle)
    {
        int itr = 0;
        //prevents hitting self with initial gaze
        this.gameObject.layer = 2;
        while (true)
        {
            //cast the ray
            RaycastHit2D hit = Physics2D.Raycast(origin,angle,100);

            Debug.DrawRay(origin, angle * 100f, Color.red);

            if (hit.collider != null)
            {
                //not the best self-check...
                if (hit.collider.gameObject.TryGetComponent(out PlayerSight sight))
                {
                    Debug.Log("OWW");
                    //die
                }

                if (hit.collider.gameObject.TryGetComponent(out Mirror mirror))
                {
                    if (mirror.isActiveAndEnabled)
                    {
                        //reflect light. Color stuff will probably go here too
                        origin = hit.point+hit.normal*0.01f;
                        angle = Vector2.Reflect(angle,hit.normal);

                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
            else
            {
                break;
            }

            itr++;
            //now you can self-hit
            this.gameObject.layer = 0;
            if (itr > 10) //change this to allow more bouncing
            {
                break;
            }
        }
    }
}

