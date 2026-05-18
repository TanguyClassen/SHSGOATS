using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public Animator animator;
    public AudioSource audioSource;
    public AudioClip doorSound;
    public GameObject highlight; // ← ajoute ça

    private bool isOpen = false;

    public void Interact()
    {
        if (!isOpen)
        {
            isOpen = true;
            animator.SetTrigger("Ouvrir");
            if (audioSource != null && doorSound != null)
                audioSource.PlayOneShot(doorSound);

            // Désactive le highlight après l'ouverture
            Invoke("DisableHighlight", 1f); // 1f = durée de l'animation
            Invoke("DisableColliders", 1f);
        }
    }

    void DisableHighlight()
    {
        if (highlight != null)
            highlight.SetActive(false);
    }

    void DisableColliders()
    {
        // Désactive les colliders des portes
        foreach (Collider col in GetComponentsInChildren<Collider>())
            col.enabled = false;
    }
}