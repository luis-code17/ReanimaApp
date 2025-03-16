using UnityEngine;
using UnityEngine.SceneManagement;
using Oculus.Interaction;

public class Menu : MonoBehaviour
{

    public void HandleButtonPress(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; // Stop game in editor
        #else
            Application.Quit(); // Quit the application in VR
        #endif
    }
}
