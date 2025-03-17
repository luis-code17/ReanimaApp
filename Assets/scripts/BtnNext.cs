using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnNext : MonoBehaviour
{
    public GameObject infoCompresion1;
    public GameObject infoCompresion2;   
    public GameObject infoCompresion3;

    




    public void NextPanel()
    {
        if (infoCompresion1.activeSelf)
        {
            infoCompresion1.SetActive(false);
            infoCompresion2.SetActive(true);
        }
        else if (infoCompresion2.activeSelf)
        {
            infoCompresion2.SetActive(false);
            infoCompresion3.SetActive(true);
        }else if (infoCompresion3.activeSelf)
        {
            infoCompresion3.SetActive(false);
            infoCompresion1.SetActive(true);
        }
    }
}