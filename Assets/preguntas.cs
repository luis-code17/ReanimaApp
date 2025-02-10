using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class preguntas : MonoBehaviour
{

    int puntuacio = 0;
    public GameObject canvas1 ;   
    public GameObject canvas2 ;
    public GameObject canvas3 ; 
    public GameObject canvas4 ;
    public GameObject canvas5 ;


    public AudioSource audio;
    public AudioClip ok;
    public AudioClip mal;

    public GameObject resposta1;
    public GameObject resposta2;
    public GameObject resposta3;
    public GameObject resposta4;

    public GameObject malament1;
    public GameObject malament2;
    public GameObject malament3;
    public GameObject malament4;

    // Start is called before the first frame update
    void Start()
    {
        canvas1.SetActive(true);
        canvas2.SetActive(false);
        canvas3.SetActive(false);
        canvas4.SetActive(false);
        canvas5.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void boto1(int num){
        Debug.Log("hola");
        int respuestaCorrecta = 1; // Aqu� defines cu�l es la respuesta correcta
        if (num==respuestaCorrecta)
        {
            sonaOk();
            puntuacio++;
            resposta1.SetActive(true);
        }else
        {
            sonaMal();
            malament1.SetActive(true);
        }
        canvas1.SetActive(false);
        canvas2.SetActive(true);
    }
    void sonaOk(){
        audio.clip=ok;
        audio.Play();
    }
    void sonaMal(){
        audio.clip=mal;
        audio.Play();
    }




    public void boto2(int num)
    {
        int respuestaCorrecta = 2; // Aqu� defines cu�l es la respuesta correcta
        if (num == respuestaCorrecta)
        {
            sonaOk();
            puntuacio++;
            resposta2.SetActive(true);
        }
        else
        {
            sonaMal();
            malament2.SetActive(true);
        }
        canvas2.SetActive(false);
        canvas3.SetActive(true);
    }


    public void boto3(int num)
    {
        int respuestaCorrecta = 2; // Aqu� defines cu�l es la respuesta correcta
        if (num == respuestaCorrecta)
        {
            sonaOk();
            puntuacio++;
            resposta3.SetActive(true);
        }
        else
        {
            sonaMal();
            malament3.SetActive(true);
        }
        canvas3.SetActive(false);
        canvas4.SetActive(true);
    }



    public void boto4(int num)
    {
        int respuestaCorrecta = 3; // Aqu� defines cu�l es la respuesta correcta
        if (num == respuestaCorrecta)
        {
            sonaOk();
            puntuacio++;
            resposta4.SetActive(true);
            // Mueve esta l�nea aqu�
        }
        else
        {
            sonaMal();
            malament4.SetActive(true);
        }
        
        // Llamamos al método CambiarEscena después de 10 segundos
        Invoke("CambiarEscena", 10f);

        //AQUI HA DE MOSTRAR LA PUNTUACIO
        // S'espera una estona i carrega la propera pantalla
    }

    public void CambiarEscena()
    {
        // Aquí cambias de escena
        // Por ejemplo, si tu escena siguiente se llama "NombreDeTuEscena", puedes hacerlo así:
        SceneManager.LoadScene("reviuvr");
    }

}
