using UnityEngine;
using System.Collections;

public class PlayerBullet : MonoBehaviour
{
    public float SPEED = 10.0f;

    private Vector3 dir;

    // Use this for initialization
    void Start()
    {
        dir.x = 0.0f;
        dir.y = 0.0f;
        dir.z = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(dir * Time.deltaTime * SPEED);
    }

    void OnCollisionEnter2D(Collision2D c2d)
    {
        if (c2d.collider.gameObject)
        {
            // if collision with something, die
            Destroy(gameObject, 0.0f);
        }
    }

    public void SetDirection(Vector3 d) { dir = d; }
    public void SetDirection(float x, float y, float z)
    {
        dir.x = x;
        dir.y = y;
        dir.z = z;
    }
    public void SetDirection(Vector2 d2)
    {
        dir.x = d2.x;
        dir.y = d2.y;
    }
}
