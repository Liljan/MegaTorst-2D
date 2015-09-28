using UnityEngine;
using System.Collections;

public class TrigonometryCycle : MonoBehaviour
{
    public bool moveX = false;
    public bool moveY = false;

    private float phase = 0.0f;
    public float frequenzy = 0.01f;
    public float amplitudeX = 0.2f;
    public float amplitudeY = 0.2f;

    void Start() { }

    void Update()
    {
        phase += 1.0f;

        if (moveX && moveY)
        {
            transform.position = new Vector3(amplitudeX * Mathf.Cos(frequenzy * phase), Mathf.Sin(frequenzy * phase), transform.position.z);
        }
        else if (moveX)
        {
            transform.position = new Vector3(amplitudeX * Mathf.Cos(frequenzy * phase), transform.position.y, transform.position.z);
        }
        else if (moveY)
        {
            transform.position = new Vector3(transform.position.x, Mathf.Sin(frequenzy * phase), transform.position.z);
        }
    }
}
