using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LockLevel : MonoBehaviour {

    public uint world, level;
    private Button b;

	// Use this for initialization
	void Start () {
        b = GetComponent<Button>();
        // badness
        try
        {
            b.interactable = Stats.level_unlock[world - 1, level - 1];
        }
        catch (System.Exception)
        {
            throw;
        }
	}
}
