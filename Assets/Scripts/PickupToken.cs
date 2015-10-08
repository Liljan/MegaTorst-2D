using UnityEngine;
using System.Collections;

public class PickupToken : MonoBehaviour
{
    public int value = 1;
    private GameMaster gm;

    private AudioSource audio;

    // Use this for initialization
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() { }

    public int GetValue() { return value; }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            gm.AddToken(value);
            AudioSource.PlayClipAtPoint(audio.clip, transform.position);
            Destroy(gameObject);
        }
    }
}