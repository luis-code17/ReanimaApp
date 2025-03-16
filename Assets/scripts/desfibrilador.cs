using UnityEngine;

public class TriggerSound : MonoBehaviour
{
    public GameObject botonDesfibrilador;
    public GameObject reaninimat;

    public AudioSource audio1; // Primer audio
    public AudioSource audio2; // Segundo audio
    public AudioSource audio3; // Tercer audio

    public void startReanimation()
    {
        botonDesfibrilador.SetActive(false);
        reaninimat.SetActive(true);

        if (!audio3.isPlaying) audio3.Play();

        Invoke("PlayAudio", 10f);
    }

    void PlayAudio()
    {
        if (!audio1.isPlaying) audio1.Play();
        if (!audio2.isPlaying) audio2.Play();
    }
}
