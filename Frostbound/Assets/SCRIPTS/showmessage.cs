


using UnityEngine;
using TMPro;

public class ShowMessage : MonoBehaviour
{
    public TextMeshProUGUI messageText;
    public string message = "Votre message ici";
    public float duration = 3f;

    void Start()
    {
        // Sauvegarde la scène actuelle pour le menu principal
        UnityEngine.SceneManagement.SceneManager.GetActiveScene();
        PlayerPrefs.SetString("LastScene", 
        UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    public void Show()
    {
        messageText.text = message;
        messageText.gameObject.SetActive(true);
        Invoke("Hide", duration);
    }

    void Hide()
    {
        messageText.gameObject.SetActive(false);
    }
}