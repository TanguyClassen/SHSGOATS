using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

public class SleepEnding : MonoBehaviour
{
    [Header("UI")]
    public GameObject endScreen;
    public Image fadeImage;
    public MonoBehaviour firstPersonController;

    [Header("Paramètres")]
    public float fadeDuration = 3f; // durée du fondu noir lent
    public string mainMenuScene = "MainMenu";

    public void Sleep()
    {
        StartCoroutine(SleepCoroutine());
    }

    IEnumerator SleepCoroutine()
    {
        // Bloque le joueur
        if (firstPersonController != null)
            firstPersonController.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Fondu noir lent
        float t = 0;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            fadeImage.color = new Color(0, 0, 0, t / fadeDuration);
            yield return null;
        }

        // Affiche THE END
        endScreen.SetActive(true);
    }

    public void WakeUp()
    {
        endScreen.SetActive(false);
        fadeImage.color = new Color(0, 0, 0, 0);

        // Réactive le joueur
        if (firstPersonController != null)
            firstPersonController.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(mainMenuScene);
    }
}