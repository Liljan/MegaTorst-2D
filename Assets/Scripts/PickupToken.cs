﻿using UnityEngine;
using System.Collections;

public class PickupToken : MonoBehaviour
{
    public int value = 1;
    private GameMaster gm;

    private Rigidbody2D rb2d;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }

    // Update is called once per frame
    void Update() { }

    public int GetValue() { return value; }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.CompareTag("Player"))
        {
            gm.AddToken(value);
            Destroy(gameObject);
        }
    }
}
