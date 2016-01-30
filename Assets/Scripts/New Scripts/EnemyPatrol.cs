using UnityEngine;
using System.Collections;

public class EnemyPatrol : MonoBehaviour
{
    public float moveSpeed;
    public bool moveRight = false;

    public Transform wallCheck;
    public float wallCheckRadius;
    public LayerMask whatIsWall;
    private bool hitWall;

    Rigidbody2D rb2d;
    private bool atEdge;
    public Transform edgeCheck;

    public GameObject deathParticles;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        hitWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, whatIsWall);
        atEdge = !Physics2D.OverlapCircle(edgeCheck.position, wallCheckRadius, whatIsWall);

        if (hitWall || atEdge) { moveRight = !moveRight; }

        if (moveRight)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);
        }
        else
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            rb2d.velocity = new Vector2(-moveSpeed, rb2d.velocity.y);
        }
    }

    public void OnTriggerEnter(Collider2D other)
    {
        if(other.tag == "Bullet")
        {
            Debug.Log("shot by a gangsta");
            StartCoroutine(Kill(1f));
        }
    }

    public IEnumerator Kill(float time)
    {
        yield return new WaitForSeconds(time);
        Instantiate(deathParticles, this.transform.position, this.transform.rotation);
        Destroy(this.gameObject);
    }
}
