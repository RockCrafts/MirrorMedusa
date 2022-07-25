using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMove : MonoBehaviour
{
    public bool active = false;
    private bool seePlayer;
    private Vector2 angle;
    public float speed = 1f;
    private Rigidbody2D rb;

    private bool dead;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        dead = this.gameObject.GetComponent<enemyDeath>().dead;
        seePlayer = GetComponent<enemySight>().seePlayer;
        if (seePlayer)
        {
            angle = GetComponent<enemySight>().angleBetween;
        }
        if (!active && seePlayer)
        {
            active = true;
        }
        if (active && !dead)
        {
            if (!seePlayer)
            {
                this.gameObject.layer = 2;
                RaycastHit2D hit = Physics2D.Raycast(transform.position, angle);
                this.gameObject.layer = 0;
                if (hit.distance <= 0.5 && hit.collider != null)
                {
                    angle = Vector2.Perpendicular(hit.normal);
                    Debug.Log(hit.collider.gameObject.name+" "+angle);
                }
            }
            rb.AddForce(angle * speed);
        }
    }
}

