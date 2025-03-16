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
    private bool haPasadoPosiciones = false; 

    void Update()
    {
        float leftWristY = leftWrist.transform.position.y * 100;
        int leftY = Mathf.FloorToInt(leftWristY);

        float rightWristY = rightWrist.transform.position.y * 100;
        int rightY = Mathf.FloorToInt(rightWristY);

        if (leftY == 11 || leftY == 12)
        {
            haPasadoPosiciones = true;
        }

        if ((leftY == 6 || leftY == 7 || leftY == 8))
        {
            if (haPasadoPosiciones) 
            {
                contador++;
                haPasadoPosiciones = false; 
            }
        }

        textoMesh.text = contador.ToString();

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
