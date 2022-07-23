using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 10f;
    private int speedPow = 2;
    public Rigidbody2D rb;
    private Vector2 movement;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();   // prevent moving faster diagonally
        
        // face direction of mouse
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.up = mousePosition - new Vector2(transform.position.x, transform.position.y);
    

    }
    private void FixedUpdate()
    {
        //weird code, partially found on internet and partially my own design. was way too tired when i wrote this so maybe you can understand better than me
        Vector2 targetSpeed = movement * playerSpeed;
        Vector2 speedDiff = targetSpeed - rb.velocity;
        float accelX = (Mathf.Abs(targetSpeed.x)>0.01f) ? 1 : -1;
        float accelY = (Mathf.Abs(targetSpeed.y)>0.01f) ? 1 : -1;
        Vector2 finalMove;
        finalMove.x = Mathf.Pow(Mathf.Abs(speedDiff.x) * accelX, speedPow) * Mathf.Sign(speedDiff.x);
        finalMove.y = Mathf.Pow(Mathf.Abs(speedDiff.y) * accelY, speedPow) * Mathf.Sign(speedDiff.y);
        rb.AddForce(finalMove);
    }


}
