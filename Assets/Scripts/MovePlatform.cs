using UnityEngine;
using System.Collections;

public class MovePlatform : MonoBehaviour
{

    public bool moveX = false;
    public bool moveY = false;

    public float period = 1.0f;
    public Vector2 amplitude;

    private float phase = 0.0f;
    private float frequenzy;
    private Vector3 startPosition;

    private Rigidbody2D rb2d;

    private Vector3 deltaPos;

    // Use this for initialization
    void Start()
    {
        try
        {
            rb2d = gameObject.GetComponent<Rigidbody2D>();
        }
        catch (System.Exception)
        {

            throw;
        }

        frequenzy = 2 * Mathf.PI / period;
        startPosition = transform.position;
        deltaPos = new Vector3(0f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        phase += Time.deltaTime;

        if (moveX && moveY)
        {
            deltaPos = new Vector3(
            startPosition.x + amplitude.x * Mathf.Cos(frequenzy * phase),
            startPosition.y + amplitude.y * Mathf.Sin(frequenzy * phase),
            transform.position.z);
        }
        else if (moveX)
        {
            deltaPos = new Vector3(
                startPosition.x + amplitude.x * Mathf.Cos(frequenzy * phase),
                rb2d.position.y,
                transform.position.z);
        }
        else if (moveY)
        {
            deltaPos = new Vector3(
                rb2d.position.x,
                startPosition.y + amplitude.y * Mathf.Sin(frequenzy * phase),
                transform.position.z);
        }


        rb2d.position = deltaPos;
    }

    void OnCollisionEnter2D(Collision2D c2d)
    {
        if (c2d.collider.CompareTag("Player"))
        {
            c2d.gameObject.transform.position = deltaPos;
        }
    }

    void OnCollisionExit2D(Collision2D c2d)
    {

        if (c2d.collider.CompareTag("Player"))
        {
            //ReleaseChild(c2d.gameObject);
        }
    }
}
