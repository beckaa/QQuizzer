using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    // Hier ist zu beachten, dass alle Szenen erst in den "Build Settings" hinzugefügt werden müssen.
    // Die Player Settings findet man unter "File -> Build Settings".
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}
