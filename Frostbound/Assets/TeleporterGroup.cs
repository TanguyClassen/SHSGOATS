using UnityEngine;

public class TeleporterGroup : MonoBehaviour
{
    public Transform destination;
    public bool checkDirection = false;
    public Vector3 requiredDirection = Vector3.forward;
    [Range(0f, 180f)]
    public float angleThreshold = 45f;

    void Start()
    {
        foreach (Transform child in transform)
        {
            // Add collider if missing
            if (child.GetComponent<Collider>() == null)
                child.gameObject.AddComponent<BoxCollider>();

            // Set as trigger
            child.GetComponent<Collider>().isTrigger = true;

            // Hide mesh
            var mr = child.GetComponent<MeshRenderer>();
            if (mr != null) mr.enabled = false;

            // Add the teleporter script and configure it
            var tp = child.gameObject.AddComponent<Teleporter>();
            tp.destination = destination;
            tp.checkDirection = checkDirection;
            tp.requiredDirection = requiredDirection;
            tp.angleThreshold = angleThreshold;
        }
    }
}