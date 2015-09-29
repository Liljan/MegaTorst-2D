using UnityEngine;
using System.Collections;

public class TrigonometryCycle : MonoBehaviour
{
    public bool moveX = false;
    public bool moveY = false;

    public float period = 1.0f;
    public Vector2 amplitude;

    private float phase = 0.0f;

    private float frequenzy;

    void Start()
    {
        frequenzy = 2 * Mathf.PI / period;
    }

    void Update()
    {
        phase += Time.deltaTime;

        if (moveX && moveY)
        {
            transform.position = new Vector3(amplitude.x * Mathf.Cos(frequenzy * phase), amplitude.y * Mathf.Sin(frequenzy * phase), transform.position.z);
        }
        else if (moveX)
        {
            transform.position = new Vector3(amplitude.x * Mathf.Cos(frequenzy * phase), transform.position.y, transform.position.z);
        }
        else if (moveY)
        {
            transform.position = new Vector3(transform.position.x, amplitude.y * Mathf.Sin(frequenzy * phase), transform.position.z);
        }
    }
}
