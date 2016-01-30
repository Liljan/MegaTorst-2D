using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    [SerializeField]
    public static int score;

    Text text;

    // Use this for initialization
    void Start()
    {
        text = GetComponent<Text>();
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = score.ToString();
    }

    public static void AddPoints(int points) { score += points; }
    public static void RevomePoints(int points) { score -= points; }
    public static void Reset() { score = 0; }
}
