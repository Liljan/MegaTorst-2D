using UnityEngine;
using System.Collections;

public class Sound : MonoBehaviour
{
    public string name;
    public AudioClip clip;

    private AudioSource source;

    [Range(0f, 1f)]
    public float volume = 0.7f;
    [Range(0.1f, 3f)]
    public float pitch = 1f;

    [Range(0f, 0.5f)]
    public float randomVolume = 0.1f;

    [Range(0f, 0.5f)]
    public float randomPitch = 0.0f;

    public void setSource(AudioSource _source)
    {
        source = _source;
        source.clip = clip;
    }

    public void Play()
    {
        source.volume = volume * (1 + Random.Range(-randomVolume / 2f, randomVolume / 2f));
        source.pitch = source.pitch = pitch * (1 + Random.Range(-randomPitch / 2f, randomPitch / 2f));
        source.PlayOneShot(source.clip, volume * MainGameManager.master_volume * MainGameManager.sfx_volume);
    }
}
