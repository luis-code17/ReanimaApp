using UnityEngine;
using TMPro;
using System.Collections;
public class testing : MonoBehaviour
{
    public GameObject leftWrist;
    public GameObject rightWrist;
    public AudioSource audioSource;

    public GameObject desfribilador;
    public GameObject gameObject;
    public GameObject gameObject2;
    public TextMeshProUGUI textoMesh;
    private int contador = 0;

    private bool haPasadoPosiciones = false; // Variable para verificar si ha pasado de la posición 12 a la posición 6
   
    void Update()
    {
        float leftWristCoordinates = leftWrist.transform.position.y * 100;
        int parteEnteraL = Mathf.FloorToInt(leftWristCoordinates);

        float rightWristCoordinates = rightWrist.transform.position.y * 100;
        int parteEnteraR = Mathf.FloorToInt(rightWristCoordinates);

        if (parteEnteraL == 11 || parteEnteraL == 12)
        {
            haPasadoPosiciones = true; // Usuario está en posición 12
        }
        
        if (parteEnteraL == 6 || parteEnteraL == 7 || parteEnteraL == 8)
        {
            if (haPasadoPosiciones) // Si ha pasado de la posición 12 a la 6
            {
                contador++;
                haPasadoPosiciones = false; // Reinicia la variable para futuros movimientos
            }
        }

        textoMesh.text = contador.ToString(); 

        if (contador == 10) 
        {
            desfribilador.SetActive(true);
            gameObject.SetActive(false);
            gameObject2.SetActive(true);
            audioSource.Play();
         
        }
    }
}


