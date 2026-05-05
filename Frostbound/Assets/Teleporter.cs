using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Transform destination;
    
    [Header("Directional (leave at None for any direction)")]
    public bool checkDirection = false;
    public Vector3 requiredDirection = Vector3.forward;
    [Range(0f, 180f)]
    public float angleThreshold = 45f;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if (checkDirection)
        {
            Vector3 playerDir = other.GetComponentInParent<CharacterController>().velocity.normalized;
            float angle = Vector3.Angle(playerDir, requiredDirection);
            if (angle > angleThreshold) return;
        }

        CharacterController cc = other.GetComponentInParent<CharacterController>();
        cc.enabled = false;
        other.transform.root.position = destination.position;
        cc.enabled = true;
    }
}