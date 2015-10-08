using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    public static GameMaster gm;
    public Transform playerPrefab;
    public Transform spawnPoint;

    public float reSpawnDelay = 1.0f;

    // UI
    public Text livesText;
    public Text tokenText;
    public Text timerText;

    // Level data
    private int lives = 3;
    private int tokens = 0;
    private float elapsedTime = 0;

    public float fallBoundary = -10;

    void Start()
    {
        if (!gm)
        {
            try
            {
                gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
               // Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }

    void Update()
    {
        UpdateTime();
        timerText.text = FormatTimeString(elapsedTime);

        livesText.text = lives.ToString();
        tokenText.text = tokens.ToString();
    }

    IEnumerator respawnPlayer()
    {
        yield return new WaitForSeconds(reSpawnDelay);
        Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    public void KillPlayer(Player p)
    {
        RemoveLife(1);
        Destroy(p.gameObject);
        gm.StartCoroutine(gm.respawnPlayer());
    }

    public void AddLife(int i)
    {
        lives += i;
      //  AudioClip ac = livesText.GetComponent<AudioClip>();
       // AudioSource.PlayClipAtPoint(ac, transform.position);
    }

    public void RemoveLife(int i) { lives -= i; }

    public void AddToken(int i)
    {
        tokens += i;

        if (tokens >= 24)
        {
            tokens = tokens % 24;
            AddLife(1);
        }
    }

    public int GetLives() { return lives; }

    public int GetTokens() { return tokens; }

    public float GetFallBoundary()
    {
        return fallBoundary;
    }

    private void UpdateTime()
    {
        elapsedTime += Time.deltaTime;
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