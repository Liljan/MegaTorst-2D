using UnityEngine;
using System.Collections;

public class MenuRotator : MonoBehaviour {

    public float speed = 10.0f;

	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0.01f * speed * Time.deltaTime, -0.01f * speed * Time.deltaTime, speed * Time.deltaTime);
	}
}
