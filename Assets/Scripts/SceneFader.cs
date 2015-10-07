using UnityEngine;
using System.Collections;

public class SceneFader : MonoBehaviour {

    private static readonly int IN = -1;
    private static readonly int OUT = 1;


    public Texture2D fadeOutTexture;
    public float fadeSpeed = 0.8f;

    private int drawDepth = -1000;
    private float alpha = 1.0f;
    private int fadeDirection = IN;

    public void OnGUI()
    {
        alpha += fadeDirection * fadeSpeed * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);

        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawDepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);
    }

    public float BeginFade(int direction)
    {
        fadeDirection = direction;
        return fadeSpeed;
    }

    public void OnLevelWasLoaded()
    {
        BeginFade(IN);
    }
}
