using UnityEngine;
using System.Collections;

public class TokenPickup : MonoBehaviour {

    public int points;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerController>())
        {
            ScoreManager.AddPoints(points);
            Destroy(this.gameObject);
        }
    }
}
