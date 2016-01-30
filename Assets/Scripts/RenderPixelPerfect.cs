using UnityEngine;
using System.Collections;

public class RenderPixelPerfect : MonoBehaviour
{
    private Vector3 realPosition;

    void LateUpdate()
    {
        realPosition = transform.position;
        transform.position = new Vector3((int)realPosition.x, (int)realPosition.y, 0);
    }

    void OnRenderObject()
    {
        transform.position = realPosition;
    }
}