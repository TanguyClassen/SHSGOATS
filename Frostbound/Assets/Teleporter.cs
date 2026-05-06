using System.Collections;
using UnityEngine;
using UnityEngine.VFX;

public class Teleporter : MonoBehaviour
{
    public Transform destination;
    public VisualEffect blizzardEffect1;
    public VisualEffect blizzardEffect2;
    public VisualEffect blizzardEffect3;
    public VisualEffect blizzardEffect4;
    public float extraDuration = 1f;
    public bool destroyAfterUse = false;
    public bool checkDirection = false;
    public Vector3 requiredDirection = Vector3.forward;
    [Range(0f, 180f)]
    public float angleThreshold = 45f;

    private static bool isTeleporting = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        if (isTeleporting) return;

        if (checkDirection)
        {
            CharacterController cc = other.transform.root.GetComponentInChildren<CharacterController>();
            if (cc == null) return;
            float angle = Vector3.Angle(cc.velocity.normalized, requiredDirection);
            if (angle > angleThreshold) return;
        }

        StartCoroutine(TeleportWithBlizzard(other));
    }

    IEnumerator TeleportWithBlizzard(Collider other)
    {
        isTeleporting = true;

        VisualEffect[] effects = { blizzardEffect1, blizzardEffect2, blizzardEffect3, blizzardEffect4 };
        var available = System.Array.FindAll(effects, e => e != null);

        yield return null;

        foreach (var e in available)
            e.SendEvent("Start");

        yield return new WaitForSeconds(extraDuration);

        CharacterController charController = other.transform.root.GetComponentInChildren<CharacterController>();
        if (charController != null)
        {
            charController.enabled = false;
            other.transform.root.position = destination.position;
            charController.enabled = true;
        }

        yield return new WaitForSeconds(1f);

        foreach (var e in available)
            e.SendEvent("Stop");

        if (destroyAfterUse)
        {
            yield return new WaitForSeconds(20f);
            Destroy(transform.parent.gameObject);
        }

        isTeleporting = false;
    }
}