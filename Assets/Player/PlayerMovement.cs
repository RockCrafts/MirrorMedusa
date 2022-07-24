using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 10f;
    private int speedPow = 2;
    private Rigidbody2D rb;
    private Vector2 movement;
    //public Vec4Variable aim;
    private Vector2 targetAngle;
    public BoolVariable eyesClosed;
    public BoolVariable paused;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            paused.Value = !paused.Value;
        }
        if (!paused.value)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            movement.Normalize();   // prevent moving faster diagonally

            // face direction of mouse
            
            //transform.up = mousePosition - new Vector2(transform.position.x, transform.position.y);

            eyesClosed.value = Input.GetButton("Fire1");
        }
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
        //aim.SetValue(targetAngle);
        //rb.SetRotation(Vector2.SignedAngle(Vector2.right, targetAngle));
    }


}
