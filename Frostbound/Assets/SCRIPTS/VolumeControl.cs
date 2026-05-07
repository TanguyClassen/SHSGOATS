using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public AudioSource ambianceSource;
    public Slider slider;

    void Start()
    {
        slider.value = ambianceSource.volume;
        slider.onValueChanged.AddListener(SetVolume);
    }

    void SetVolume(float value)
    {
        ambianceSource.volume = value;
    }
}