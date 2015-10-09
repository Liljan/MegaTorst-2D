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
            rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
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
            MakeChild(c2d.gameObject);
        }
    }

    void OnCollisionExit2D(Collision2D c2d)
    {

        if (c2d.collider.CompareTag("Player"))
        {
            ReleaseChild(c2d.gameObject);
        }
    }

    private void MakeChild(GameObject g)
    {
        Debug.Log("Made child");
        rb2d.isKinematic = true;
        g.transform.parent = this.gameObject.transform;
    }

    private void ReleaseChild(GameObject g)
    {
        rb2d.isKinematic = false;
        g.transform.parent = null;
    }
}
