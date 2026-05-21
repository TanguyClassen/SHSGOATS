using UnityEngine;

public class AudioZoneManager : MonoBehaviour
{
    public AudioSource[] sourcesToMute;   // musique ambiance, vent, etc
    public AudioSource[] sourcesToPlay;   // audio de la zone pingu
    
    private float[] originalVolumes;

    void Start()
    {
        // Sauvegarde les volumes originaux
        originalVolumes = new float[sourcesToMute.Length];
        for (int i = 0; i < sourcesToMute.Length; i++)
            originalVolumes[i] = sourcesToMute[i].volume;
    }

    public void EnterZone()
    {
        // Coupe les autres audios
        foreach (AudioSource source in sourcesToMute)
            source.volume = 0f;

        // Lance les audios de la zone
        foreach (AudioSource source in sourcesToPlay)
            source.Play();
    }

    public void ExitZone()
    {
        // Restaure les volumes originaux
        for (int i = 0; i < sourcesToMute.Length; i++)
            sourcesToMute[i].volume = originalVolumes[i];

        // Arrête les audios de la zone
        foreach (AudioSource source in sourcesToPlay)
            source.Stop();
    }
}