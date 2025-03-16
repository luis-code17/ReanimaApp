using System.Collections;
using UnityEngine;

public class AlternarCanvasColor : MonoBehaviour
{
    public Canvas canvas; // El Canvas al que se le cambiará el color

    void Start()
    {
        if (canvas == null)
        {
            canvas = GetComponent<Canvas>(); // Si no se asignó en el Inspector, lo obtenemos automáticamente
        }
        StartCoroutine(CambiarColorCanvas());
    }

    IEnumerator CambiarColorCanvas()
    {
        CanvasRenderer canvasRenderer = canvas.GetComponent<CanvasRenderer>();
        if (canvasRenderer == null)
        {
            Debug.LogError("No se encontró el CanvasRenderer en el Canvas.");
            yield break; // Si no se encuentra el CanvasRenderer, salimos de la corutina
        }

        while (true)
        {
            // Alterna entre dos colores (puedes modificar los colores según tu preferencia)
            canvasRenderer.SetColor(canvasRenderer.GetColor() == Color.white ? Color.green : Color.white);
            yield return new WaitForSeconds(0.5f); // Espera 0.5 segundos
        }
    }
}
