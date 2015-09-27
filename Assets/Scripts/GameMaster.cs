using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour
{
    public static GameMaster gm;
    public Transform playerPrefab;
    public Transform spawnPoint;

    public float spawnDelay = 1.0f;
    public Transform spawnPrefab;


    // Level data
    private int lives = 3;
    private int tokens = 0;

    void Start()
    {
        if (!gm)
        {
            try
            {
                gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
            }
            catch (System.Exception)
            {
                Debug.Log("Die snek");
                throw;
            }
        }
    }

    void Update() { }

    IEnumerator respawnPlayer()
    {
        yield return new WaitForSeconds(spawnDelay);
        Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
        // Instantiate(spawnPrefab, spawnPoint.position, spawnPoint.rotation);
        Debug.Log("Respawn'd");
    }

    public static void KillPlayer(Player p)
    {
        Destroy(p.gameObject);
        gm.StartCoroutine(gm.respawnPlayer());
    }

    public void AddLife(int i) { lives += i; }
    public void RemoveLife(int i) { lives -= i; }

    public void addToken(int i)
    {
        tokens += i;

        if (tokens % 24 == 0)
        {
            tokens = 0;
            lives++;
        }
    }

    public int getLives() { return lives; }

    public int getTokens() { return tokens; }
}
