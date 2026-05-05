using UnityEngine;

public class FootstepSound : MonoBehaviour
{
    [Header("Audio")]
    public AudioClip[] footstepClips;
    public AudioSource audioSource;

    [Header("Paramètres")]
    public float stepInterval = 0.5f;
    public float minSpeed = 0.1f;

    private CharacterController cc;
    private float stepTimer = 0f;

    void Start()
    {
        cc = GetComponent<CharacterController>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();
    }

    void Update()
    {
        bool isMoving = cc.velocity.magnitude > minSpeed && cc.isGrounded;

        if (isMoving)
        {
            stepTimer -= Time.deltaTime;
            if (stepTimer <= 0f)
            {
                PlayFootstep();
                stepTimer = stepInterval;
            }
        }
        else
        {
            stepTimer = 0f;
        }
    }

    void PlayFootstep()
    {
        if (footstepClips.Length == 0) return;
        AudioClip clip = footstepClips[Random.Range(0, footstepClips.Length)];
        audioSource.PlayOneShot(clip);
    }
}