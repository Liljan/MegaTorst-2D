using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    public static GameMaster gm;
    public Transform playerPrefab;
    public Transform spawnPoint;

    public float spawnDelay = 1.0f;
    public Transform spawnPrefab;

    // UI
    public Text tokenText;

    // Level data
    private int lives = 3;
    private int tokens = 0;

    public float fallBoundary = -10;

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
                throw;
            }
        }
    }

    void Update()
    {
        //tokenText.text = "Beer: " + tokens;
    }

    IEnumerator respawnPlayer()
    {
        yield return new WaitForSeconds(spawnDelay);
        Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    public static void KillPlayer(Player p)
    {
        Destroy(p.gameObject);
        gm.StartCoroutine(gm.respawnPlayer());
    }

    public void AddLife(int i) { lives += i; }
    public void RemoveLife(int i) { lives -= i; }

    public void AddToken(int i)
    {
        tokens += i;

        if (tokens % 24 == 0)
        {
            tokens = 0;
            lives++;
        }
    }

    public int GetLives() { return lives; }

    public int GetTokens() { return tokens; }

    public float GetFallBoundary()
    {
        return fallBoundary;
    }
}
