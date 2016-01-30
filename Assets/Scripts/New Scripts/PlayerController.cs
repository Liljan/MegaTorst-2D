using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpHeight;

    Rigidbody2D rb2d;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;

    private bool grounded = false;
    private bool doubleJumped = false;

    // Use this for initialization
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    // Update is called once per frame
    void Update()
    {
        if (grounded)
            doubleJumped = false;

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            Jump();
        }
        else if (Input.GetKeyDown(KeyCode.Space) && !doubleJumped && !grounded)
        {
            Jump();
            doubleJumped = true;
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb2d.velocity = new Vector2(-moveSpeed, rb2d.velocity.y);
        }

    }

    public void Jump()
    {
        rb2d.velocity = new Vector2(rb2d.velocity.x, jumpHeight);
    }
}
