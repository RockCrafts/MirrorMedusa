using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySight : MonoBehaviour
{
    public GameObject player;
    private Vector2 angleBetween;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
         float angle = Mathf.Atan2(player.transform.position.y-transform.position.y,player.transform.position.x-transform.position.x);
        angleBetween.x = Mathf.Cos(angle);
        angleBetween.y = Mathf.Sin(angle);
        checkForPlayer(transform.position,angleBetween);
    }

    bool checkForPlayer(Vector2 origin,Vector2 angle){
         //prevents hitting self with initial gaze
        Debug.DrawRay(origin,angle*10f);

        this.gameObject.layer = 2;
        RaycastHit2D hit = Physics2D.Raycast(origin,angle);
        this.gameObject.layer = 0;
        if(hit.collider != null){
            if(hit.collider.gameObject.Equals(player)){
                Debug.Log("See you");
                return true;
            }
                Debug.Log("See not you");

        }
        Debug.Log("See nothing");
        return false;
    }
}
