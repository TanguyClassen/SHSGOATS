using UnityEngine;
using UnityEngine.InputSystem;
using NarrationsJouables;

public class BinocularsView : MonoBehaviour
{
    [Header("Références")]
    public Camera mainCamera;
    public GameObject binocularsOverlay;
    public MonoBehaviour firstPersonController;
    public MonoBehaviour firstPersonAim;

    [Header("Paramètres")]
    public float zoomedFOV = 15f;
    public float normalFOV = 60f;
    public float zoomSpeed = 5f;
    public float mouseSensitivity = 2f;

    private bool isActive = false;
    private float targetFOV;
    private float rotationX = 0f;
    private float rotationY = 0f;

    void Start()
    {
        targetFOV = normalFOV;
        if (mainCamera == null)
            mainCamera = Camera.main;
    }

    public void Activate()
    {
        isActive = true;
        binocularsOverlay.SetActive(true);
        targetFOV = zoomedFOV;

        rotationX = mainCamera.transform.eulerAngles.y;
        rotationY = mainCamera.transform.eulerAngles.x;

        if (firstPersonController != null)
            firstPersonController.enabled = false;
        if (firstPersonAim != null)
            firstPersonAim.enabled = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Deactivate()
    {
        isActive = false;
        binocularsOverlay.SetActive(false);
        targetFOV = normalFOV;

        if (firstPersonController != null)
            firstPersonController.enabled = true;
        if (firstPersonAim != null)
            firstPersonAim.enabled = true;
    }

    void Update()
    {
        mainCamera.fieldOfView = Mathf.Lerp(
            mainCamera.fieldOfView,
            targetFOV,
            Time.deltaTime * zoomSpeed
        );

        if (!isActive) return;

        float mouseX = Mouse.current.delta.x.ReadValue() * mouseSensitivity * Time.deltaTime;
        float mouseY = Mouse.current.delta.y.ReadValue() * mouseSensitivity * Time.deltaTime;

        rotationX += mouseX;
        rotationY -= mouseY;
        rotationY = Mathf.Clamp(rotationY, -60f, 60f);

        mainCamera.transform.rotation = Quaternion.Euler(rotationY, rotationX, 0f);

        if (Keyboard.current.escapeKey.wasPressedThisFrame)
            Deactivate();
    }
}