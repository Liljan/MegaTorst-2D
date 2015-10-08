using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {

    private GameObject child;
    private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {

    }

    void OnTriggerExit2D(Collider2D col)
    {

    }
}
