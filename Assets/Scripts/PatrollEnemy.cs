using UnityEngine;
using System.Collections;

public class PatrollEnemy : MonoBehaviour {

    public LayerMask enemyMask;
    public float speed = 1;
    Rigidbody2D myBody;
    Transform myTrans;
    float myWidth, myHeight;

    // Use this for initialization
    void Start () {
        myTrans = this.transform;
        myBody = this.GetComponent<Rigidbody2D>();
        myWidth = this.GetComponent<SpriteRenderer>().bounds.extents.x;
        myHeight = this.GetComponent<SpriteRenderer>().bounds.extents.y;
    }
	
	// Update is called once per frame
	void FixedUpdate()
    {
        Vector2 lineCastPos = myTrans.position.toVector2() - myTrans.right.toVector2() * myWidth + Vector2.up * myHeight;
        bool isGrounded = Physics2D.Linecast(lineCastPos, lineCastPos + new Vector2(0f,-1000f), enemyMask);

        Debug.DrawLine(lineCastPos, lineCastPos - myTrans.right.toVector2()*0.05f);
        bool isBlocked = Physics2D.Linecast(lineCastPos, lineCastPos - myTrans.right.toVector2() * 0.05f, enemyMask);

        if(!isGrounded || isBlocked)
        {
            Vector3 currRot = myTrans.eulerAngles;
            currRot.y += 180;
            myTrans.eulerAngles = currRot;
        }

        Vector2 myVel = myBody.velocity;
        myVel.x -= myTrans.right.x * speed;
        myBody.velocity = myVel;
    }
}
