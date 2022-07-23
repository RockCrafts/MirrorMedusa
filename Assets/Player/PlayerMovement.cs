using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   public float playerSpeed = 5f;
   
   public Rigidbody2D rb;
   private Vector2 movement;

   private void Start()
   {
      rb = GetComponent<Rigidbody2D>();
   }
  
   private void Update() {
      movement.x = Input.GetAxisRaw("Horizontal");
      movement.y = Input.GetAxisRaw("Vertical");
      // face direction of mouse
      Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
      transform.up = mousePosition - new Vector2(transform.position.x, transform.position.y);
     

   }
   private void FixedUpdate()
   {
      rb.MovePosition(rb.position + movement * playerSpeed * Time.fixedDeltaTime);
   }


}
