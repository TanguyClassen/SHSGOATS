using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public Animator animator;
    public AudioSource audioSource;
    public AudioClip doorSound;

    private bool isOpen = false;

    public void Interact()
    {
        if (!isOpen)
        {
            isOpen = true;
            animator.SetTrigger("Ouvrir");
            if (audioSource != null && doorSound != null)
                audioSource.PlayOneShot(doorSound);
        }
    }
}