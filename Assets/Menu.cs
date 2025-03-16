using UnityEngine;
using UnityEngine.SceneManagement;
using Oculus.Interaction;

public class Menu : MonoBehaviour
{
    public string sceneName; 

    private void Start()
    {
        PokeInteractable pokeButton = GetComponent<PokeInteractable>();

        if (pokeButton != null)
        {
            pokeButton.WhenSelect.AddListener(HandleButtonPress);
        }
    }

    private void HandleButtonPress()
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName); 
        }
        else
        {
            QuitGame(); // Salir del juego si sceneName está vacío
        }
    }

    private void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; // Detener juego en el editor
        #else
            Application.Quit(); // Cerrar la aplicación en VR
        #endif
    }
}
