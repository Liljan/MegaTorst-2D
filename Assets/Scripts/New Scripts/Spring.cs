using UnityEngine;
using System.Collections;

public class Spring : MonoBehaviour
{
    [Range(0f, 100f)]
    public float force;

    private Animator anim;
    private bool jumped = false;

    private AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        anim = this.gameObject.GetComponent<Animator>();
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Jump", jumped);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        Rigidbody2D rb2d = other.GetComponent<Rigidbody2D>();

        if (rb2d)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, force);
            jumped = true;
            audioSource.PlayOneShot(audioSource.clip);
        }
    }

    private IEnumerator Bounce(float time)
    {
        yield return new WaitForSeconds(time);
        jumped = false;
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        StartCoroutine(Bounce(0.1f));
    }

}
