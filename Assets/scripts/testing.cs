using UnityEngine;
using TMPro;

public class Testing : MonoBehaviour
{
    public GameObject leftWrist;
    public GameObject rightWrist;
    public AudioSource audioSource;

    public GameObject desfribilador;
    public GameObject gameObject;
    public GameObject gameObject2;
    public GameObject gameObject3;
    public GameObject gameObject4;
    public TextMeshProUGUI textoMesh;

    private int contador = 0;
    private bool haPasadoPosiciones = false; // Para verificar si ha pasado de la posición alta a baja

    void Update()
    {
        // Obtener la posición Y de ambas manos en valores enteros (multiplicado por 100)
        float leftWristY = leftWrist.transform.position.y * 100;
        int leftY = Mathf.FloorToInt(leftWristY);

        float rightWristY = rightWrist.transform.position.y * 100;
        int rightY = Mathf.FloorToInt(rightWristY);

        // Si cualquiera de las dos manos está en posición alta (11 o 12)
        if (leftY == 11 || leftY == 12 || rightY == 11 || rightY == 13 || rightY == 14 )
        {
            haPasadoPosiciones = true;
        }

        // Si cualquiera de las dos manos baja a 6, 7 u 8
        if ((leftY == 6 || leftY == 7 || leftY == 8) && (rightY == 7 || rightY == 8 || rightY == 9 || rightY == 10 ))
        {
            if (haPasadoPosiciones) // Si antes estuvo en la posición alta
            {
                contador++;
                haPasadoPosiciones = false; // Reiniciar para la próxima detección
            }
        }

        // Actualizar el texto con el contador
        textoMesh.text = contador.ToString();

        // Si el contador llega a 10, activar el desfribilador y otros objetos
        if (contador == 10)
        {
            desfribilador.SetActive(true);
            gameObject.SetActive(false);
            gameObject2.SetActive(true);
            gameObject3.SetActive(false);
            gameObject4.SetActive(true);
            audioSource.Play();
        }
    }
}
