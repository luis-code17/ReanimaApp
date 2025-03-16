using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;  


[System.Serializable]
public class Pregunta
{
    public string pregunta;
    public string resposta1;
    public string resposta2;
    public string resposta3;
    public string resposta4;
}

[System.Serializable]
public class Preguntas
{
    public List<Pregunta> preguntas;
}

public class Questions : MonoBehaviour
{
    int puntuacio = 0;
    public GameObject canvas;

    public GameObject canvasResponse;

    public AudioSource audio;
    public AudioClip ok;
    public AudioClip mal;

    public TMPro.TextMeshPro  resposta1;
    public TMPro.TextMeshPro  resposta2;
    public TMPro.TextMeshPro  resposta3;
    public TMPro.TextMeshPro  resposta4;


    public TMPro.TextMeshProUGUI pregunta;
    public TMPro.TextMeshProUGUI resultado;

    private Preguntas preguntas;
    private List<Pregunta> preguntasRandom = new List<Pregunta>();

    private int preguntaActualIndex = 0;
    private string respostaCorrecta;


    // Start is called before the first frame update
    void Start()
    {
        puntuacio = 0;
        preguntaActualIndex = 0;
        preguntasRandom.Clear();
        canvas.SetActive(true);
        canvasResponse.SetActive(false);
        LoadQuestions();
    
        // Seleccionar 5 preguntas aleatorias de la lista
        List<Pregunta> preguntasList = new List<Pregunta>(preguntas.preguntas);
        for (int i = 0; i < 5; i++)
        {
            int random = Random.Range(0, preguntasList.Count); // Elegir un índice aleatorio
            preguntasRandom.Add(preguntasList[random]); // Añadir la pregunta a la lista de preguntas aleatorias
            preguntasList.RemoveAt(random); // Eliminar la pregunta de la lista original
        }

        ShowQuestion();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void ShowQuestion()
    {
        if (preguntaActualIndex >= 5)  
        {

            resultado.text = "Has acertado " + puntuacio + " de 5 preguntas.";
            canvas.SetActive(false);
            canvasResponse.SetActive(true);
            return;
        }

        Pregunta preguntaActual = preguntasRandom[preguntaActualIndex]; // Seleccionar la pregunta actual
        respostaCorrecta = preguntaActual.resposta1; // Guardamos la respuesta correcta

        List<string> respuestas = new List<string>
        {
            preguntaActual.resposta1,
            preguntaActual.resposta2,
            preguntaActual.resposta3,
            preguntaActual.resposta4
        };

        // Mezclar el orden de las respuestas sin repetir
        for (int i = respuestas.Count - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1); // Elegir un índice aleatorio entre 0 e i
            (respuestas[i], respuestas[randomIndex]) = (respuestas[randomIndex], respuestas[i]); // Intercambio
        }


        pregunta.text = preguntaActual.pregunta;
        resposta1.text = respuestas[0];
        resposta2.text = respuestas[1];
        resposta3.text = respuestas[2];
        resposta4.text = respuestas[3];

       
    }


    void LoadQuestions()
    {
        string json = @"
        {
            ""preguntas"": [
                {
                    ""pregunta"": ""¿Qué significa RCP?"",
                    ""resposta1"": ""Reanimación cardiopulmonar."",
                    ""resposta2"": ""Recuperación cardiopulmonar."",
                    ""resposta3"": ""Reacción cardíaca primaria."",
                    ""resposta4"": ""Rehabilitación cardíaca profesional.""
                },
                {
                    ""pregunta"": ""¿Cuál es el primer paso antes de iniciar RCP?"",
                    ""resposta1"": ""Verificar seguridad."",
                    ""resposta2"": ""Comenzar compresiones."",
                    ""resposta3"": ""Dar ventilaciones."",
                    ""resposta4"": ""Llamar al hospital.""
                },
                {
                    ""pregunta"": ""¿Cuántas compresiones por minuto se deben realizar?"",
                    ""resposta1"": ""100-120."",
                    ""resposta2"": ""Menos de 60."",
                    ""resposta3"": ""Alrededor de 50."",
                    ""resposta4"": ""No importa.""
                },
                {
                    ""pregunta"": ""¿Cuál es la profundidad correcta de las compresiones?"",
                    ""resposta1"": ""5 cm."",
                    ""resposta2"": ""Menos de 2 cm."",
                    ""resposta3"": ""3 cm."",
                    ""resposta4"": ""Más de 10 cm.""
                },
                {
                    ""pregunta"": ""¿Cuál es la relación de compresiones y ventilaciones?"",
                    ""resposta1"": ""30:2."",
                    ""resposta2"": ""15:1."",
                    ""resposta3"": ""40:5."",
                    ""resposta4"": ""No fija.""
                },
                {
                    ""pregunta"": ""¿Qué se debe hacer si la víctima no responde?"",
                    ""resposta1"": ""Iniciar RCP."",
                    ""resposta2"": ""Dar agua."",
                    ""resposta3"": ""Esperar ambulancia."",
                    ""resposta4"": ""Sacudir víctima.""
                },
                {
                    ""pregunta"": ""¿Cuándo se debe usar un DEA?"",
                    ""resposta1"": ""Inmediatamente, sin pulso."",
                    ""resposta2"": ""Si está consciente."",
                    ""resposta3"": ""Solo en niños."",
                    ""resposta4"": ""Después de 30 minutos.""
                },
                {
                    ""pregunta"": ""¿Cómo se deben colocar las manos en RCP?"",
                    ""resposta1"": ""Centro del pecho."",
                    ""resposta2"": ""Lado izquierdo."",
                    ""resposta3"": ""Bajo el ombligo."",
                    ""resposta4"": ""En el cuello.""
                },
                {
                    ""pregunta"": ""¿Cada cuánto rotar reanimadores?"",
                    ""resposta1"": ""Cada 2 minutos."",
                    ""resposta2"": ""Cada 10 minutos."",
                    ""resposta3"": ""Cuando se cansen."",
                    ""resposta4"": ""No es necesario.""
                },
                {
                    ""pregunta"": ""¿Qué hacer si la víctima empieza a respirar?"",
                    ""resposta1"": ""Detener RCP, posición recuperación."",
                    ""resposta2"": ""Continuar RCP."",
                    ""resposta3"": ""Más compresiones."",
                    ""resposta4"": ""Esperar que hable.""
                },
                {
                    ""pregunta"": ""¿Qué hacer si la víctima vomita durante RCP?"",
                    ""resposta1"": ""Girar a un lado."",
                    ""resposta2"": ""No hacer nada."",
                    ""resposta3"": ""Limpiar boca."",
                    ""resposta4"": ""Reanudar compresiones.""
                },
                {
                    ""pregunta"": ""¿Qué hacer si no hay DEA disponible?"",
                    ""resposta1"": ""Continuar RCP."",
                    ""resposta2"": ""Esperar ayuda."",
                    ""resposta3"": ""Buscar DEA."",
                    ""resposta4"": ""Dar ventilaciones.""
                },
                {
                    ""pregunta"": ""¿Cuál es el ritmo correcto de las compresiones?"",
                    ""resposta1"": ""Rápido y firme."",
                    ""resposta2"": ""Lento y suave."",
                    ""resposta3"": ""No importa."",
                    ""resposta4"": ""Interrumpir frecuentemente.""
                },
                {
                    ""pregunta"": ""¿Cómo saber si las compresiones son efectivas?"",
                    ""resposta1"": ""Movimiento del pecho."",
                    ""resposta2"": ""Pulso visible."",
                    ""resposta3"": ""Cuerpo caliente."",
                    ""resposta4"": ""Respiración normal.""
                }
            ]
        }";


        preguntas = JsonUtility.FromJson<Preguntas>(json);
    }

  
    public void VerificarRespuesta(int botonSeleccionado)
    {
        Debug.Log("Botón seleccionado: " + botonSeleccionado);
        string respuestaSeleccionada = "";
        switch (botonSeleccionado)
        {
            case 1:
                respuestaSeleccionada = resposta1.text;
                break;
            case 2:
                respuestaSeleccionada = resposta2.text;
                break;
            case 3:
                respuestaSeleccionada = resposta3.text;
                break;
            case 4:
                respuestaSeleccionada = resposta4.text;
                break;
        }

        if (respuestaSeleccionada == respostaCorrecta)
        {
            sonaOk();
            puntuacio++;
        }
        else
        {
            sonaMal();
        }

        preguntaActualIndex++;
        ShowQuestion();
    }

    void sonaOk()
    {
        audio.clip = ok;
        audio.Play();
    }

    void sonaMal()
    {
        audio.clip = mal;
        audio.Play();
    }

    public void tryAgain()
    {
        Start();
    }

    public void nextScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("reviuvrGame");
    }
}

