using UnityEngine; 
using System.Collections;

public class MenuScript : MonoBehaviour
{
    string sceneName = "PRlab_ApplySpinStation";
    public void ChangeScene(string sceneName)
    {
        Application.LoadLevel(sceneName);
    }
}