using UnityEngine;
using System.Collections;

public class EnemyBird : MonoBehaviour
{
    public LayerMask enemyMask;
    Rigidbody2D myBody;
    Transform myTrans;
    float myWidth, myHeight;

    public float speed;

    public Animator anim;
    public const float maxDist = 1f;

    // public vars
    public float health = 1f;
    private bool alive = true;

    private float currDist = 0f;

    void Start()
    {
        myTrans = this.transform;
        myBody = this.GetComponent<Rigidbody2D>();
        SpriteRenderer mySprite = this.GetComponent<SpriteRenderer>();
        myWidth = mySprite.bounds.extents.x;
        myHeight = mySprite.bounds.extents.y;

        anim = GetComponent<Animator>();
        anim.SetBool("Alive", true);
    }

    void FixedUpdate()
    {
        //Use this position to cast the isGrounded/isBlocked lines from
        Vector2 lineCastPos = myTrans.position.toVector2() + myTrans.right.toVector2() * myWidth + Vector2.up * myHeight;

        Debug.DrawLine(lineCastPos, lineCastPos + myTrans.right.toVector2() * .05f);
        bool isBlocked = Physics2D.Linecast(lineCastPos, lineCastPos + myTrans.right.toVector2() * .05f, enemyMask);

        //If theres no ground, turn around. Or if I hit a wall, turn around
        if (isBlocked || currDist > maxDist)
        {
            Vector3 currRot = myTrans.eulerAngles;
            currRot.y += 180;
            myTrans.eulerAngles = currRot;
            currDist = 0f;
        }

        if (alive)
        {
            Vector2 myVel = myBody.velocity;
            myVel.x = myTrans.right.x * speed;
            currDist += Mathf.Abs(myVel.x*Time.deltaTime);
            Debug.Log(currDist);
            myBody.velocity = myVel;
        }

    }

    void OnCollisionEnter2D(Collision2D c2d)
    {
        if (c2d.collider.CompareTag("Player"))
        {
            alive = false;
            anim.SetBool("Alive", alive);
            StartCoroutine(this.Kill());
        }
    }

    void TakeDamage(float f)
    {
        health -= f;
    }

    IEnumerator Kill()
    {
        //GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(0.1f);
        Destroy(this.gameObject);
    }
}