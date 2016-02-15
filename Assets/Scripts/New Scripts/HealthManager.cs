using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {

    public int maxPlayerHealth;
    public static int playerHealth;

    private LevelManager lm;

    private Text text;

    private bool isDead = false;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        lm = FindObjectOfType<LevelManager>();
        SetFullHealth();
	}
	
	// Update is called once per frame
	void Update () {
        if (playerHealth <= 0)
        {
            lm.RespawnPlayer();
        }

        text.text = playerHealth.ToString();
	}

    public static void RemoveHealth(int damage) {
        playerHealth -= damage;
        FindObjectOfType<PlayerLifeBar>().RemoveHealth();

    }
    public static void GiveHealth(int health) {
        playerHealth += health;
        FindObjectOfType<PlayerLifeBar>().AddHealth();
    }
    public void SetFullHealth() {
        playerHealth = maxPlayerHealth;
        FindObjectOfType<PlayerLifeBar>().SetFullHealth();
    }
}
