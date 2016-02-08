using UnityEngine;
using System.Collections;

public class Stomp : MonoBehaviour {

    public int damage;

    private PlayerController player;

    private AudioSource audioSource;

    // Use this for initialization
    void Start () {
        player = transform.parent.GetComponent<PlayerController>();
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            other.GetComponent<EnemyHealthManager>().TakeDamage(damage);
            player.Jump();
            player.SetDoubleJumped(false);
            audioSource.PlayOneShot(audioSource.clip);
        }
    }
}
