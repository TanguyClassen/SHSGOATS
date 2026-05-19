using UnityEngine;
using NarrationsJouables;

public class OpenDoor : MonoBehaviour
{
    public Animator animator;
    public AudioSource audioSource;
    public AudioClip doorSound;
    public GameObject highlight;
    public Collider[] doorColliders;

    private bool isOpen = false;

    public void Interact()
    {
        if (!isOpen)
        {
            isOpen = true;
            animator.SetTrigger("Ouvrir");
            if (audioSource != null && doorSound != null)
                audioSource.PlayOneShot(doorSound);
            Invoke("DisableHighlight", 1f);
            Invoke("DisableColliders", 1f);
        }
    }

    void DisableHighlight()
    {
        if (highlight != null)
        {
            // Désactive tous les Mesh Renderers du highlight
            foreach (MeshRenderer mr in highlight.GetComponentsInChildren<MeshRenderer>())
                mr.enabled = false;
        }

        ActionableItem actionable = GetComponent<ActionableItem>();
        if (actionable != null)
            actionable.enabled = false;
    }

    void DisableColliders()
    {
        foreach (Collider col in doorColliders)
            col.enabled = false;
    }
}