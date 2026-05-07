using UnityEngine;
using UnityEngine.InputSystem;
public class PCInterface : MonoBehaviour
{
    public GameObject panel;
    public MonoBehaviour firstPersonController;
    private bool isOpen = false;

    void Start()
    {
        panel.SetActive(false);
    }

    public void Open()
    {
        isOpen = true;
        panel.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        if (firstPersonController != null)
            firstPersonController.enabled = false;
    }
    public void Close()
    {
        isOpen = false;
        panel.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        if (firstPersonController != null)
            firstPersonController.enabled = true;
    }
    void Update()
    {
        if (isOpen && Keyboard.current.escapeKey.wasPressedThisFrame)
            Close();
    }
}