using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RandomString : MonoBehaviour {

    public Text text;
    public string[] list;

	// Use this for initialization
	void Start ()
    {
        int i = Random.Range(0, list.Length);
        text.text = list[i];
	}
}
