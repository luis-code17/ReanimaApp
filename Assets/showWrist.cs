using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class showWrist : MonoBehaviour
{
    public GameObject leftWrist; // Referencia al objeto del que queremos obtener las coordenadas
    public TextMeshProUGUI Texto; // Referencia al objeto con TextMeshPro

    // Update is called once per frame
    void Update()
    {
    float leftWristCoordinates = (leftWrist.transform.position.y) * 100;
    int parteEnteraL = Mathf.FloorToInt(leftWristCoordinates);
    Texto.text=parteEnteraL.ToString();
    }
}

