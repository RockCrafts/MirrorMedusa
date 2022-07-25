using UnityEngine;

public class Enemy : Seeable
{
    public Transform player;
    [Tooltip("The amount of time until the enemy becomes a mirror")]
    public float deathTime = 2f;
    public float speed = 1f;
    [Min(0)] public float drag = 1f;
    private float deathTimer;
    private Vector2 aim;
    private Rigidbody2D rb;
    private Mirror mirror;
    private bool seen, seesPlayer;
    public SpriteRenderer alive, dead;
    private void OnEnable()
    {
        whenSeen.AddListener(HandleSeen);
    }
    private void OnDisable()
    {
        whenSeen.RemoveListener(HandleSeen);
    }
    public bool IsDead
    {
        get
        {
            return deathTimer <= 0;
        }
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        mirror = GetComponent<Mirror>();
        mirror.enabled = false;
        alive.color = mirror.reflectedColor;
        dead.color = mirror.reflectedColor;
        seen = false;
        deathTimer = deathTime;
    }
    void HandleSeen(Color c)
    {
        seen = true;
    }
    void Update()
    {
        if (deathTimer <= 0)
        {
            dead.enabled = true;
            alive.enabled = false;
            mirror.enabled = true;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        else
        {
            dead.enabled = false;
            alive.enabled = true;
            if (seen)
            {
                deathTimer -= Time.deltaTime;
            }
            else
            {
                aim = (player.position - transform.position).normalized;
                if (aim.x > 0)
                {
                    dead.flipX = false;
                    alive.flipX = false;
                }
                if (aim.x < 0)
                {
                    dead.flipX = true;
                    alive.flipX = true;
                }
                seesPlayer = CheckForPlayer(transform.position, aim);
                if(seesPlayer)
                {
                    print("Enemy sees player");
                }
            }
        }
    }
    private void FixedUpdate()
    {
        if (seesPlayer && deathTimer > 0)
        {
            print(aim * speed);
            rb.velocity = aim * speed;
        }
        rb.AddForce(rb.velocity * -drag);
    }

    bool CheckForPlayer(Vector2 origin, Vector2 angle)
    {
        //prevents hitting self with initial gaze
        Debug.DrawRay(origin, angle * 10f);

        this.gameObject.layer = 2;
        RaycastHit2D hit = Physics2D.Raycast(origin, angle);
        this.gameObject.layer = 0;
        if (hit)
        {
            if (hit.collider.gameObject.TryGetComponent(out PlayerMovement p))
            {
                return true;
            }

        }
        return false;
    }
}
