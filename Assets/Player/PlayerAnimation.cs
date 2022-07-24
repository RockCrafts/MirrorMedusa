using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] Vec4Variable dir;

    [Header("Sprite Directional Refrences")]
    [SerializeField] Sprite up;
    [SerializeField] Sprite left;
    [SerializeField] Sprite right;
    [SerializeField] Sprite down;
    private SpriteRenderer spriteRenderer;

    private PlayerSight playerSight;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerSight = GetComponentInParent<PlayerSight>();
    }

   public void Update() {
    
        float angle = Vector2.SignedAngle((Vector2) transform.position, ((Vector2) dir.Value));
        if(angle > -45 && angle < 45)
        {
            spriteRenderer.sprite = right;
            // 1.6 1.5
        }
        else if(angle > 45 && angle < 135)
        {
            spriteRenderer.sprite = up;
            // 0 1.5 
            
        }
        else if(angle > 135 || angle < -135)
        {
            spriteRenderer.sprite = left;
            // -2.5 1.5
        }
        else
        {
            spriteRenderer.sprite = down;
               // 0 1.5
        }
   }
}
