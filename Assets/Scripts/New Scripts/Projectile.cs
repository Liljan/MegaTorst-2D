using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    public float speed;

    private PlayerController player;
    private Rigidbody2D rb2d;

    public int damage = 1;

    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        rb2d = FindObjectOfType<Rigidbody2D>();

        // default local scale is -1f, 1f, 1f

        if (player.transform.localScale.x < 0)
        {
            this.transform.localScale = new Vector3(-1f, 1f, 1f);
            speed = -speed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!rb2d)
        {
            Destroy(this.gameObject);
        }
        rb2d.velocity = new Vector2(speed, 0f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<EnemyHealthManager>().TakeDamage(damage);
        }
        Destroy(this.gameObject);
    }
}
