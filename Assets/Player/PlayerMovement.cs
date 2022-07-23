using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 5f;

    public Rigidbody2D rb;
    private Vector2 movement;
    public Vector2 visionAngle;
    private SpriteRenderer renderer;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();   // prevent moving faster diagonally
        // face direction of mouse
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //transform.up = mousePosition - new Vector2(transform.position.x, transform.position.y);
        visionAngle = mousePosition - new Vector2(transform.position.x, transform.position.y);
        if (visionAngle.x > 0)
        {
            renderer.flipX = false;
        }
        else
        {
            renderer.flipX = true;
        }
    }


    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * playerSpeed * Time.fixedDeltaTime);
    }


}
