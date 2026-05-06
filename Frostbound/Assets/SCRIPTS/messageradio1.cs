using UnityEngine;
using TMPro;

public class ShowMessage : MonoBehaviour
{
    public TextMeshProUGUI messageText;
    public string message = "Voici votre message !";
    public float duration = 3f;

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