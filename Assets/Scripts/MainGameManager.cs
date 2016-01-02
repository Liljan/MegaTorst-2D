using UnityEngine;
using System.Collections;

public class MainGameManager : MonoBehaviour
{
    public static MainGameManager instance;

    public const string GAME_NAME = "MEGA-TORST 2D";

    public static bool isPaused = false;

    // SOUND OPTIONS
    public static float master_volume = 1.0f;
    public static float sfx_volume = 1.0f;
    public static float music_volume = 1.0f;

    // getters and setters
    public void setMasterVolume(float f) { master_volume = f; }
    public float getMasterVolume() { return master_volume; }
    public void setSFXVolume(float f) { sfx_volume = f; }
    public float getSFXVolume() { return sfx_volume; }
    public void setMusicVolume(float f) { music_volume = f; }
    public float getMusicVolume() { return music_volume; }

    void Awake()
    {
        instance = this;
        Debug.Log("LET'SA GO; MOTHERFUCKER!");
    }

    // Use this for initialization
    void Start()
    {}
}
