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

    private Animator anim;

    private float moveVelocity = 0f;

    public Transform firePoint;
    public GameObject shot;

    // Use this for initialization
    void Start()
    {
        rb2d = this.gameObject.GetComponent<Rigidbody2D>();
        anim = this.gameObject.GetComponent<Animator>();
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

        if (Input.GetKeyDown(KeyCode.W) && grounded)
        {
            Jump();
        }
        else if (Input.GetKeyDown(KeyCode.W) && !doubleJumped && !grounded)
        {
            Jump();
            doubleJumped = true;
        }

        moveVelocity = 0f;

        if (Input.GetKey(KeyCode.D))
        {
            // rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);
            moveVelocity = moveSpeed;
        }

        if (Input.GetKey(KeyCode.A))
        {
           // rb2d.velocity = new Vector2(-moveSpeed, rb2d.velocity.y);
            moveVelocity = -moveSpeed;
        }

        rb2d.velocity = new Vector2(moveVelocity, rb2d.velocity.y);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            // fire
            Instantiate(shot, firePoint.transform.position, firePoint.transform.rotation);
        }

        // Animation
        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));
        if (rb2d.velocity.x > 0)
        { //moving right
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (rb2d.velocity.x < 0)
        {
            // move left
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        anim.SetBool("Grounded", grounded);
    }

    public void Jump()
    {
        rb2d.velocity = new Vector2(rb2d.velocity.x, jumpHeight);
    }
}
