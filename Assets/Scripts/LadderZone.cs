using UnityEngine;
using System.Collections;
using UnityStandardAssets;
using UnitySampleAssets;

public class LadderZone : MonoBehaviour {

   // private  PlatformerCharacter2D burt;

	void Start () {
	
	}
	
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
           // Player p = col.gameObject as Player;
           // p.isOnLadder(true);
        }
    }
}
