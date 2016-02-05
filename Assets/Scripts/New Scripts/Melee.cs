using UnityEngine;
using System.Collections;

public class Melee : MonoBehaviour
{
    [Range(0, 100)]
    public int damage;

    private bool attacking = false;

    private BoxCollider2D col;
    // Use this for initialization
    void Start()
    {
        col = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetAttacking(bool b) { attacking = b; }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (attacking)
        {
            if (other.tag == "Enemy")
            {
                other.GetComponent<EnemyHealthManager>().TakeDamage(damage);
            }
        }
    }
}
