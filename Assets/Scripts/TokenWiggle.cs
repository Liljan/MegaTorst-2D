using UnityEngine;
using System.Collections;

public class TokenWiggle : MonoBehaviour
{

    private float phase = 0.0f;
    public float amplitude = 0.2f;
    public float frequenzy = 0.01f;

    void Start() { }

    void Update()
    {
        phase += 1.0f;
        transform.position = new Vector3(transform.position.x,
            amplitude * Mathf.Sin(frequenzy * phase),
            transform.position.z);
    }
}
