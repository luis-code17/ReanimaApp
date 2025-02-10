using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eyeanimation : MonoBehaviour
{
    public AudioSource audioSource;
        public AudioSource audioSource2;
        public GameObject gameObject;
        public GameObject gameObject2;


    // Start is called before the first frame update
    void Start()
    {
            Invoke("ReproducirAnimacionDespuesDelAudio", 10f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    void ReproducirAnimacionDespuesDelAudio()
    {
        // Activa el trigger en el Animator
        audioSource.Play();
        audioSource2.Play();
        gameObject.SetActive(false);
        gameObject2.SetActive(true);    
    }
}
