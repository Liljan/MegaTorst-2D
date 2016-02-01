using UnityEngine;
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

    // Use this for initialization
    void Start()
    {
        healthManager = FindObjectOfType<HealthManager>();
        RespawnPlayer();
        
    }

    // Update is called once per frame
    void Update()
    {
        
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

}
