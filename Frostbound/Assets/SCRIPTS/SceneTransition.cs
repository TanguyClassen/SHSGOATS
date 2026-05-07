using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SceneTransition : MonoBehaviour
{
    public static SceneTransition instance;
    private Image fadeImage;
    public float fadeDuration = 1f;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        GameObject canvas = new GameObject("FadeCanvas");
        Canvas c = canvas.AddComponent<Canvas>();
        c.renderMode = RenderMode.ScreenSpaceOverlay;
        c.sortingOrder = 999;
        DontDestroyOnLoad(canvas);

        GameObject imgObj = new GameObject("FadeImage");
        imgObj.transform.SetParent(canvas.transform, false);
        fadeImage = imgObj.AddComponent<Image>();
        fadeImage.color = new Color(0, 0, 0, 0);
        RectTransform rt = imgObj.GetComponent<RectTransform>();
        rt.anchorMin = Vector2.zero;
        rt.anchorMax = Vector2.one;
        rt.offsetMin = Vector2.zero;
        rt.offsetMax = Vector2.zero;
    }

    public void GoToScene(string sceneName)
    {
        StartCoroutine(FadeAndLoad(sceneName));
    }

    IEnumerator FadeAndLoad(string sceneName)
    {
        // Trouve la musique d'ambiance
        GameObject musicObj = GameObject.Find("MusiqueAmbiance");
AudioSource music = musicObj != null ? musicObj.GetComponent<AudioSource>() : null;
        float startVolume = music != null ? music.volume : 0f;

        float t = 0;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            float ratio = t / fadeDuration;

            // Fondu écran vers noir
            fadeImage.color = new Color(0, 0, 0, ratio);

            // Fade out musique
            if (music != null)
                music.volume = Mathf.Lerp(startVolume, 0f, ratio);

            yield return null;
        }

        // Charge la scène
        SceneManager.LoadScene(sceneName);

        // Fondu depuis le noir
        t = fadeDuration;
        while (t > 0)
        {
            t -= Time.deltaTime;
            fadeImage.color = new Color(0, 0, 0, t / fadeDuration);
            yield return null;
        }

        fadeImage.color = new Color(0, 0, 0, 0);
    }
}