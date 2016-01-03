using UnityEngine;
using System.Collections;

public class Stats : MonoBehaviour
{
    public static Stats instance;

    // Level unlocks
    public static bool[,] level_unlock = new bool[,]
    {
        {true,false,false,false,false },
        {false,false,false,false,false },
        {false,false,false,false,false },
        {false,false,false,false,false },
    };

    // Statistics
    public static uint total_beer = 0;
    public static uint total_deaths = 0;
    public static uint total_continues = 0;

    void Awake()
    {
        instance = this;
        Debug.Log("There has been an awakening. Have you felt it?");
    }

    // Use this for initialization
    void Start()
    {}
}
