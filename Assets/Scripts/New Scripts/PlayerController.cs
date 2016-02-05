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

        if ((Input.GetKeyDown(KeyCode.W)) && grounded)
        {
            Jump();
            audioSource.PlayOneShot(SFX_JUMP);
        }
        else if (Input.GetKeyDown(KeyCode.W) && !doubleJumped && !grounded)
        {
            Jump();
            doubleJumped = true;
            audioSource.PlayOneShot(SFX_DOUBLE_JUMP);
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

        if (Input.GetKeyDown(KeyCode.Space) && readyToShoot)
        {
            Fire(shootDelay);
        }

        // Attacking

        if (Input.GetKeyDown(KeyCode.C))
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

    private void ReadyToShoot(){ readyToShoot = true; }
}
