using UnityEngine;
using System.Collections;

public class Knockback : MonoBehaviour
{

    public int damage = 1;
    public bool knockBack = true;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            HealthManager.RemoveHealth(damage);
            PlayerController player = other.GetComponent<PlayerController>();
            player.SetKnockBack(other.transform.position);
        }
    }
}
