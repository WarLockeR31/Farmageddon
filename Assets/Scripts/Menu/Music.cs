using UnityEngine;

public class AlternateMusic : MonoBehaviour
{
    public AudioSource musicSource1;
    public AudioSource musicSource2;

    private AudioSource currentSource;

    void Start()
    {
        if (musicSource1 == null || musicSource2 == null)
        {
            Debug.LogError("AudioSources не присвоены!");
            return;
        }

        currentSource = musicSource1;
        currentSource.Play();
    }

    void Update()
    {
        if (!currentSource.isPlaying)
        {
            currentSource = (currentSource == musicSource1) ? musicSource2 : musicSource1;
            currentSource.Play();
        }
    }
}
