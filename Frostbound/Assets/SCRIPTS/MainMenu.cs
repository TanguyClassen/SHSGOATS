using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public string sceneJeu = "Interieur";
    public AudioSource musiqueMenu;
    public float fadeDuration = 1.5f;
    public Image fadeImage;

    void Start()
    {
        // S'assure que le fondu commence noir puis s'éclaircit
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        float t = fadeDuration;
        while (t > 0)
        {
            t -= Time.deltaTime;
            fadeImage.color = new Color(0, 0, 0, t / fadeDuration);
            yield return null;
        }
        fadeImage.color = new Color(0, 0, 0, 0);
    }

    public void Jouer()
    {
        StartCoroutine(FadeOutAndLoad());
    }

    IEnumerator FadeOutAndLoad()
    {
        float t = 0;
        float startVolume = musiqueMenu.volume;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            float ratio = t / fadeDuration;

            // Fondu écran
            fadeImage.color = new Color(0, 0, 0, ratio);

            // Fade out musique
            musiqueMenu.volume = Mathf.Lerp(startVolume, 0f, ratio);

            yield return null;
        }

        SceneManager.LoadScene(sceneJeu);
    }
}