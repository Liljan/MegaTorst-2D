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
    public float shootDelay = 2f;
    private bool readyToShoot = true;

    // knockback
    public float knockBackForce;
    public float knockbackLength;
    public float knockBackTime;
    public bool knockFromRight;

    // melee attack
    private bool attacking = false;
    private Melee meleeHandler;

    // ladder
    public bool onLadder = false;
    public float climbSpeed;
    private float climbVelocity;
    private float gravityStore;

    // sound effects
    private AudioSource audioSource;
    public AudioClip SFX_JUMP;
    public AudioClip SFX_DOUBLE_JUMP;

    // Use this for initialization
    void Start()
    {
        rb2d = this.gameObject.GetComponent<Rigidbody2D>();
        anim = this.gameObject.GetComponent<Animator>();
        audioSource = this.gameObject.GetComponent<AudioSource>();
        meleeHandler = GetComponentInChildren<Melee>();

        gravityStore = rb2d.gravityScale;
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

        // Check input

        if (Input.GetButtonDown("Jump") && grounded && !onLadder)
        {
            Jump();
            audioSource.PlayOneShot(SFX_JUMP);
        }
        else if (Input.GetButtonDown("Jump") && !doubleJumped && !grounded && !onLadder)
        {
            Jump();
            doubleJumped = true;
            audioSource.PlayOneShot(SFX_DOUBLE_JUMP);
        }

        // movement
        moveVelocity = moveSpeed * Input.GetAxisRaw("Horizontal");

        rb2d.velocity = new Vector2(moveVelocity, rb2d.velocity.y);

        if (Input.GetButtonDown("Fire") && readyToShoot)
        {
            Fire(shootDelay);
        }

        // Attacking

        if (Input.GetButtonDown("Melee"))
        {
            Attack(0.2f);
        }

        // knockback
        if (knockBackTime <= 0)
        {
            rb2d.velocity = new Vector2(moveVelocity, rb2d.velocity.y);
        }
        else
        {
            if (knockFromRight)
            {
                rb2d.velocity = new Vector2(-knockBackForce, knockBackForce);
            }
            else
            {
                rb2d.velocity = new Vector2(knockBackForce, knockBackForce);
            }
            knockBackTime -= Time.deltaTime;
        }

        // Ladder climbing
        if (onLadder)
        {
            rb2d.gravityScale = 0f;
            climbVelocity = climbSpeed * Input.GetAxisRaw("Vertical");
            rb2d.velocity = new Vector2(rb2d.velocity.x, climbVelocity);
        }
        if(!onLadder)
        {
            rb2d.gravityScale = gravityStore;
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
        anim.SetBool("Attacking", attacking);
    }

    public void Jump()
    {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpHeight);
    }

    private void Fire(float delay)
    {
        Instantiate(shot, firePoint.transform.position, firePoint.transform.rotation);
        readyToShoot = false;
        Invoke("ReadyToShoot", delay);
    }

    public void SetKnockBack(Vector3 t)
    {
        knockBackTime = knockbackLength;
        knockFromRight = (t.x < transform.position.x);
    }

    public void Attack(float time)
    {
        attacking = true;
        meleeHandler.SetAttacking(true);
        Invoke("SetAttackingFalse", time);
    }

    // bad shiet
    private void SetAttackingFalse()
    {
        attacking = false;
        meleeHandler.SetAttacking(false);
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if(other.transform.tag == "Moving Platform")
        {
            transform.parent = other.transform;
        }
    }

    public void OnCollisionExit2D(Collision2D other)
    {
        if (other.transform.tag == "Moving Platform")
        {
            transform.parent = null;
        }
    }

    private void ReadyToShoot() { readyToShoot = true; }
    public void SetDoubleJumped(bool b) { doubleJumped = b; }
    public void SetOnLadder(bool b) { onLadder = b; }
}
