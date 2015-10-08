using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour {

    public void SetScene(string sceneIndex)
    {
        try
        {
            Application.LoadLevel(sceneIndex);
        }
        catch (System.Exception)
        {
            throw;
        }
    }
}
