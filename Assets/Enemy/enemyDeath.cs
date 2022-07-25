using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDeath : MonoBehaviour
{
    public bool dying;
    public bool dead;
    public int maxDeathTimer = 60;
    private int deathTimer;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Mirror>().enabled = false;
    deathTimer = maxDeathTimer;
    dying = false;
    dead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(dying){
            Debug.Log("WHYYYY");
                        deathTimer--;
            if(deathTimer == 0){
                dead = true;
            }
        }
        if(dead){
            GetComponent<Mirror>().enabled = true;
        }
    }
}
