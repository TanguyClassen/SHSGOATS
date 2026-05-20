using UnityEngine;
using UnityEngine.VFX;

public class TeleporterGroup : MonoBehaviour
{
    public Transform destination;
    public VisualEffect blizzardEffect1;
    public VisualEffect blizzardEffect2;
    public VisualEffect blizzardEffect3;
    public VisualEffect blizzardEffect4;
    public float extraDuration = 1f;
    public bool checkDirection = false;
    public Vector3 requiredDirection = Vector3.forward;
    [Range(0f, 180f)]
    public float angleThreshold = 45f;
    public bool destroyAfterUse = false;

    void Awake()
    {
        
        if (destination != null)
        {
            var destMr = destination.GetComponent<MeshRenderer>();
            if (destMr != null) destMr.enabled = false;
        }

        foreach (Transform child in transform)
        {
            if (child.GetComponent<Collider>() == null)
                child.gameObject.AddComponent<BoxCollider>();

            child.GetComponent<Collider>().isTrigger = true;

            var mr = child.GetComponent<MeshRenderer>();
            if (mr != null) mr.enabled = false;

            var tp = child.gameObject.AddComponent<Teleporter>();
            tp.destination = destination;
            tp.blizzardEffect1 = blizzardEffect1;
            tp.blizzardEffect2 = blizzardEffect2;
            tp.blizzardEffect3 = blizzardEffect3;
            tp.blizzardEffect4 = blizzardEffect4;
            tp.extraDuration = extraDuration;
            tp.checkDirection = checkDirection;
            tp.requiredDirection = requiredDirection;
            tp.angleThreshold = angleThreshold;
            tp.destroyAfterUse = destroyAfterUse;
        }
    }
}