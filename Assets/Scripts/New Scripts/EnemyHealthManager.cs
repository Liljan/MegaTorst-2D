using UnityEngine;
using System.Collections;

public class EnemyHealthManager : MonoBehaviour
{

    public int health;
    public GameObject deathEffect;
    public int points;

    // Use this for initialization
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Kill();
        }
    }

    private void Kill()
    {
        Instantiate(deathEffect, transform.position, transform.rotation);
        ScoreManager.AddPoints(points);
        Destroy(this.gameObject);
    }

    public void TakeDamage(int damage) { health -= damage; }
}
