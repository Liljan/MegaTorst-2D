using UnityEngine;
using System.Collections;

public class FallingPlatform : MonoBehaviour
{

    private Rigidbody2D rb2d;
    public float fallDelay = 1.0f;

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
            StartCoroutine(Fall());
        }
    }

    IEnumerator Fall()
    {
        yield return new WaitForSeconds(fallDelay);
        rb2d.isKinematic = false;
        GetComponent<Collider2D>().isTrigger = true;


        yield return new WaitForSeconds(10.0f);
        Destroy(gameObject, 0.0f);

        yield return 0;
    }
}
