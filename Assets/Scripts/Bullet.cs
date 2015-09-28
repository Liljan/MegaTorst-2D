using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Vector3 dir = new Vector3();

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(10.0f, 0.0f);

        Destroy(this.gameObject, 10.0f);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SetDirection(float x, float y)
    {
        dir.x = x;
        dir.y = y;
    }

    public void SetVelocity(float x, float y)
    {
        rb2d.velocity = new Vector2(x, y);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.isTrigger)
        {
            Destroy(this.gameObject);
        }
         
    }
}
