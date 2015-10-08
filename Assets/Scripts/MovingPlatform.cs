using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour
{
    private GameObject child;
    private Rigidbody2D rb2d;

    // Use this for initialization
    void Start()
    {
        try
        {
            rb2d = GetComponent<Rigidbody2D>();
        }
        catch (System.Exception)
        {

            throw;
        }
    }

    void OnCollisionEnter2D(Collision2D c2d)
    {
        if (c2d.collider.CompareTag("Player"))
        {
            Debug.Log("Hello!");
            c2d.transform.parent = this.transform;
        }
    }

    void OnCollisionExit2D(Collision2D c2d)
    {

        if (c2d.collider.CompareTag("Player"))
        {
            c2d.transform.parent = null;
        }
    }
}
