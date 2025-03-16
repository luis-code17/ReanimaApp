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
    public string idioma;
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
        string jsonES = @"
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

        string jsonEN = @"
        {
            ""preguntas"": [
                {
                    ""pregunta"": ""What does CPR stand for?"",
                    ""resposta1"": ""Cardiopulmonary resuscitation."",
                    ""resposta2"": ""Cardiopulmonary recovery."",
                    ""resposta3"": ""Primary cardiac reaction."",
                    ""resposta4"": ""Professional cardiac rehabilitation.""
                },
                {
                    ""pregunta"": ""What is the first step before starting CPR?"",
                    ""resposta1"": ""Check for safety."",
                    ""resposta2"": ""Start compressions."",
                    ""resposta3"": ""Give ventilations."",
                    ""resposta4"": ""Call the hospital.""
                },
                {
                    ""pregunta"": ""How many compressions per minute should be performed?"",
                    ""resposta1"": ""100-120."",
                    ""resposta2"": ""Less than 60."",
                    ""resposta3"": ""Around 50."",
                    ""resposta4"": ""It doesn’t matter.""
                },
                {
                    ""pregunta"": ""What is the correct compression depth?"",
                    ""resposta1"": ""5 cm."",
                    ""resposta2"": ""Less than 2 cm."",
                    ""resposta3"": ""3 cm."",
                    ""resposta4"": ""More than 10 cm.""
                },
                {
                    ""pregunta"": ""What is the compression-to-ventilation ratio?"",
                    ""resposta1"": ""30:2."",
                    ""resposta2"": ""15:1."",
                    ""resposta3"": ""40:5."",
                    ""resposta4"": ""Not fixed.""
                },
                {
                    ""pregunta"": ""What should you do if the victim does not respond?"",
                    ""resposta1"": ""Start CPR."",
                    ""resposta2"": ""Give water."",
                    ""resposta3"": ""Wait for an ambulance."",
                    ""resposta4"": ""Shake the victim.""
                },
                {
                    ""pregunta"": ""When should an AED be used?"",
                    ""resposta1"": ""Immediately, if no pulse."",
                    ""resposta2"": ""If they are conscious."",
                    ""resposta3"": ""Only on children."",
                    ""resposta4"": ""After 30 minutes.""
                },
                {
                    ""pregunta"": ""Where should hands be placed during CPR?"",
                    ""resposta1"": ""Center of the chest."",
                    ""resposta2"": ""Left side."",
                    ""resposta3"": ""Below the navel."",
                    ""resposta4"": ""On the neck.""
                },
                {
                    ""pregunta"": ""How often should rescuers switch roles?"",
                    ""resposta1"": ""Every 2 minutes."",
                    ""resposta2"": ""Every 10 minutes."",
                    ""resposta3"": ""When they get tired."",
                    ""resposta4"": ""Not necessary.""
                },
                {
                    ""pregunta"": ""What should you do if the victim starts breathing?"",
                    ""resposta1"": ""Stop CPR, place in recovery position."",
                    ""resposta2"": ""Continue CPR."",
                    ""resposta3"": ""Give more compressions."",
                    ""resposta4"": ""Wait for them to speak.""
                },
                {
                    ""pregunta"": ""What should you do if the victim vomits during CPR?"",
                    ""resposta1"": ""Turn them to one side."",
                    ""resposta2"": ""Do nothing."",
                    ""resposta3"": ""Clean their mouth."",
                    ""resposta4"": ""Resume compressions.""
                },
                {
                    ""pregunta"": ""What if no AED is available?"",
                    ""resposta1"": ""Continue CPR."",
                    ""resposta2"": ""Wait for help."",
                    ""resposta3"": ""Look for an AED."",
                    ""resposta4"": ""Give ventilations.""
                },
                {
                    ""pregunta"": ""What is the correct compression rhythm?"",
                    ""resposta1"": ""Fast and firm."",
                    ""resposta2"": ""Slow and gentle."",
                    ""resposta3"": ""It doesn’t matter."",
                    ""resposta4"": ""Interrupt frequently.""
                },
                {
                    ""pregunta"": ""How do you know if compressions are effective?"",
                    ""resposta1"": ""Chest movement."",
                    ""resposta2"": ""Visible pulse."",
                    ""resposta3"": ""Warm body."",
                    ""resposta4"": ""Normal breathing.""
                }
            ]
        }";


        if(idioma == "EN")
        {
            preguntas = JsonUtility.FromJson<Preguntas>(jsonEN);
        }
        else
        {
            preguntas = JsonUtility.FromJson<Preguntas>(jsonES);
        }

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

