using UnityEngine;
using System.Collections;

public class PlaySound : MonoBehaviour {

    public void playSound(AudioSource au)
    {
        au.PlayOneShot(au.clip, MainGameManager.master_volume * MainGameManager.sfx_volume);
    }
}
