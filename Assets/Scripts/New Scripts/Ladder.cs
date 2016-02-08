using UnityEngine;
using System.Collections;

public class Ladder : MonoBehaviour {

    private PlayerController player;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        if (!player)
        {
            FindPlayer();
        }
	
	}

    private void FindPlayer()
    {
        player = FindObjectOfType<PlayerController>();
        if (player)
        {
            Debug.Log("found player");
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            player.SetOnLadder(true);
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            player.SetOnLadder(false);
        }
    }
}
