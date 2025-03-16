using UnityEngine;

public class TriggerSound : MonoBehaviour
{
    public GameObject botonDesfibrilador;
    public GameObject reaninimat;

    public AudioSource audio1; // Primer audio
    public AudioSource audio2; // Segundo audio
private void OnTriggerEnter(Collider other)
{
    Debug.Log("Trigger activado por: " + other.name);

    if (other.CompareTag("Player") || other.name.Contains("Hand")) 
    {
        Debug.Log("Las manos han activado el trigger");

        botonDesfibrilador.SetActive(false);
        reaninimat.SetActive(true);

        if (!audio1.isPlaying) audio1.Play();
        if (!audio2.isPlaying) audio2.Play();
    }
}

}
