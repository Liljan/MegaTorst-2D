using UnityEngine;
using System.Collections;

[System.Serializable]
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField]
    Sound[] sounds;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one AudioManager in the scene.");
        }
        else
        {
            instance = this;
        }
    }

    void Start()
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            GameObject _go = new GameObject("Sound_" + i + "_" + sounds[i].name);
            _go.transform.SetParent(this.transform);
            sounds[i].setSource(_go.AddComponent<AudioSource>());
        }
    }

    public void PlaySound(string _name)
    {
        foreach (Sound item in sounds)
        {
            if (item.name == _name)
            {
                item.Play();
                return;
            }
        }

        // no sound with that name
        Debug.LogWarning("AudioManager: Sound not found in list, " + _name);
    }

    void Update()
    {

    }
}
