using UnityEngine;

public class LetterInterface : MonoBehaviour
{
    public GameObject letterPanel;
    public MonoBehaviour firstPersonController;

    private bool isOpen = false;

public void Open()
{
    isOpen = true;
    letterPanel.SetActive(true);
    Time.timeScale = 0f;
    Cursor.lockState = CursorLockMode.None;
    Cursor.visible = true;
    if (firstPersonController != null)
        firstPersonController.enabled = false;
}

    public void Close()
    {
        isOpen = false;
        letterPanel.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        if (firstPersonController != null)
            firstPersonController.enabled = true;
    }
}