using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public float health = 100.0f;
    private GameMaster gm;
    private float fallBoundary = -10.0f;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }

    void Update()
    {
        CheckFallBoundary();
    }

    public float GetHealth() { return health; }
    public void SetHealth(float h) { health = h; }
    public void takeDamage(float d)
    {
        health -= d;
        if (health <= 0)
        {
            gm.KillPlayer(this);
        }
    }

    private void CheckFallBoundary()
    {
        if (transform.position.y <= fallBoundary)
        {
            takeDamage(90000.0f);
        }
    }
}