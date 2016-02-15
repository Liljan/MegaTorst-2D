using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    public GameObject currentCheckpoint;
    private PlayerController player;
    public PlatformerCamera cam;

    public GameObject deathParticle;
    public GameObject spawnParticle;
    public GameObject playerPrefab;

    public float respawnDelay;

    private HealthManager healthManager;

    // UI
    private float elapsedTime = 0;
    public Text timerText;

    // Use this for initialization
    void Start()
    {
        healthManager = FindObjectOfType<HealthManager>();
        RespawnPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTime();

    }

    public void KillPlayer()
    {
        Instantiate(deathParticle, player.transform.position, player.transform.rotation);
        Destroy(player.gameObject);
        RespawnPlayer();
    }


    public void RespawnPlayer()
    {
        Instantiate(playerPrefab, currentCheckpoint.transform.position, currentCheckpoint.transform.rotation);
        player = FindObjectOfType<PlayerController>();
        cam.FindPlayer();
        Instantiate(spawnParticle, player.transform.position, player.transform.rotation);

        healthManager.SetFullHealth();
    }

    private void UpdateTime()
    {
        elapsedTime += Time.deltaTime;
        timerText.text = FormatTimeString(elapsedTime);
    }

    private string FormatTimeString(float e)
    {
        int d = (int)(elapsedTime * 100.0f);
        int minutes = d / (60 * 100);
        int seconds = (d % (60 * 100)) / 100;
        int hundredths = d % 100;

        return string.Format("{0:00}:{1:00}.{2:00}", minutes, seconds, hundredths);
    }

}
