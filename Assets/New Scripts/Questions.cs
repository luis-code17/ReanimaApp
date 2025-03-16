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
    private string idioma_respuesta;
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

    public TMPro.TextMeshPro  continuarRes;
    public TMPro.TextMeshPro  reintentarRes;



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
            if(idioma_respuesta == "CAT")
            {
                resultado.text = "Has encertat " + puntuacio + " de 5 preguntes.";
                continuarRes.text = "Continuar";
                reintentarRes.text = "Tornar a intentar";
            }
            else if(idioma_respuesta == "EN")
            {
                resultado.text = "You have answered " + puntuacio + " of 5 questions.";
                continuarRes.text = "Continue";
                reintentarRes.text = "Try again";
            }else
            {
                resultado.text = "Has acertado " + puntuacio + " de 5 preguntas.";
                continuarRes.text = "Continuar";
                reintentarRes.text = "Volver a intentar";
            }
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

        string jsonCAT = @"
        {
            ""preguntas"": [
                {
                    ""pregunta"": ""Què significa RCP?"",
                    ""resposta1"": ""Reanimació cardiopulmonar."",
                    ""resposta2"": ""Recuperació cardiopulmonar."",
                    ""resposta3"": ""Reacció cardíaca primària."",
                    ""resposta4"": ""Rehabilitació cardíaca professional.""
                },
                {
                    ""pregunta"": ""Quin és el primer pas abans d'iniciar RCP?"",
                    ""resposta1"": ""Verificar seguretat."",
                    ""resposta2"": ""Començar compressions."",
                    ""resposta3"": ""Donar ventilacions."",
                    ""resposta4"": ""Trucar a l'hospital.""
                },
                {
                    ""pregunta"": ""Quantes compressions per minut s'han de fer?"",
                    ""resposta1"": ""100-120."",
                    ""resposta2"": ""Menys de 60."",
                    ""resposta3"": ""Al voltant de 50."",
                    ""resposta4"": ""No importa.""
                },
                {
                    ""pregunta"": ""Quina és la profunditat correcta de les compressions?"",
                    ""resposta1"": ""5 cm."",
                    ""resposta2"": ""Menys de 2 cm."",
                    ""resposta3"": ""3 cm."",
                    ""resposta4"": ""Més de 10 cm.""
                },
                {
                    ""pregunta"": ""Quina és la relació de compressions i ventilacions?"",
                    ""resposta1"": ""30:2."",
                    ""resposta2"": ""15:1."",
                    ""resposta3"": ""40:5."",
                    ""resposta4"": ""No fixa.""
                },
                {
                    ""pregunta"": ""Què s'ha de fer si la víctima no respon?"",
                    ""resposta1"": ""Iniciar RCP."",
                    ""resposta2"": ""Donar aigua."",
                    ""resposta3"": ""Esperar ambulància."",
                    ""resposta4"": ""Sacsejar la víctima.""
                },
                {
                    ""pregunta"": ""Quan s'ha d'utilitzar un DEA?"",
                    ""resposta1"": ""Immediatament, sense pols."",
                    ""resposta2"": ""Si està conscient."",
                    ""resposta3"": ""Només en nens."",
                    ""resposta4"": ""Després de 30 minuts.""
                },
                {
                    ""pregunta"": ""Com s'han de col·locar les mans en RCP?"",
                    ""resposta1"": ""Al centre del pit."",
                    ""resposta2"": ""Al costat esquerre."",
                    ""resposta3"": ""Sota el melic."",
                    ""resposta4"": ""Al coll.""
                },
                {
                    ""pregunta"": ""Cada quant s'han de rotar els reanimadors?"",
                    ""resposta1"": ""Cada 2 minuts."",
                    ""resposta2"": ""Cada 10 minuts."",
                    ""resposta3"": ""Quan es cansin."",
                    ""resposta4"": ""No és necessari.""
                },
                {
                    ""pregunta"": ""Què fer si la víctima comença a respirar?"",
                    ""resposta1"": ""Aturar RCP, posició de recuperació."",
                    ""resposta2"": ""Continuar RCP."",
                    ""resposta3"": ""Més compressions."",
                    ""resposta4"": ""Esperar que parli.""
                },
                {
                    ""pregunta"": ""Què fer si la víctima vomita durant RCP?"",
                    ""resposta1"": ""Girar-la de costat."",
                    ""resposta2"": ""No fer res."",
                    ""resposta3"": ""Netejar la boca."",
                    ""resposta4"": ""Reprendre compressions.""
                },
                {
                    ""pregunta"": ""Què fer si no hi ha un DEA disponible?"",
                    ""resposta1"": ""Continuar RCP."",
                    ""resposta2"": ""Esperar ajuda."",
                    ""resposta3"": ""Buscar un DEA."",
                    ""resposta4"": ""Donar ventilacions.""
                },
                {
                    ""pregunta"": ""Quin és el ritme correcte de les compressions?"",
                    ""resposta1"": ""Ràpid i ferm."",
                    ""resposta2"": ""Lent i suau."",
                    ""resposta3"": ""No importa."",
                    ""resposta4"": ""Interrompre freqüentment.""
                },
                {
                    ""pregunta"": ""Com saber si les compressions són efectives?"",
                    ""resposta1"": ""Moviment del pit."",
                    ""resposta2"": ""Pols visible."",
                    ""resposta3"": ""Cos calent."",
                    ""resposta4"": ""Respiració normal.""
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


        if(idioma == "CAT")
        {
            idioma_respuesta = "CAT";
            preguntas = JsonUtility.FromJson<Preguntas>(jsonCAT);
        }
        else if(idioma == "EN")
        {
            idioma_respuesta = "EN";
            preguntas = JsonUtility.FromJson<Preguntas>(jsonEN);
        }
        else
        {
            idioma_respuesta = "ES";
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

    public void nextScene(string scene)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
    }
}

