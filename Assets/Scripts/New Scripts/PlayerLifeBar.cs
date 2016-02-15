using UnityEngine;
using System.Collections;

public class PlayerLifeBar : MonoBehaviour {

    public GameObject[] livesList;

    private int currentHealth;
    private int totalHealth;

	// Use this for initialization
	void Start () {
        totalHealth = livesList.Length;
        currentHealth = totalHealth;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    // Can only add/remove one life at the time

    public void AddHealth()
    {
        currentHealth++;
        livesList[currentHealth].SetActive(true);
    }

    public void RemoveHealth()
    {
        currentHealth--;
        Debug.Log("Invisible");
        livesList[currentHealth].SetActive(false);
    }

    public void SetFullHealth()
    {
        currentHealth = livesList.Length;
        for(int i = 0; i < livesList.Length; ++i)
        {
            livesList[i].SetActive(true);
        }
    }
}
