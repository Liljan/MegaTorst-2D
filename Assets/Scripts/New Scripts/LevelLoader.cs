using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour {

    private bool playerInZone = false;
    public string levelToLoad;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Jump") && playerInZone)
        {
            Application.LoadLevel(levelToLoad);
        }
	}

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            playerInZone = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerInZone = false;
        }
    }
}
