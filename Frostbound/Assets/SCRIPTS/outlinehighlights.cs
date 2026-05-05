using UnityEngine;

public class OutlineHighlight : MonoBehaviour
{
    private Outline outline;
    public float maxDistance = 3f;
    private bool isHighlighted = false;

    void Start()
    {
        outline = GetComponent<Outline>();
        if (outline != null) outline.enabled = false;
    }

    public void SetHighlight(bool active)
    {
        if (outline != null) outline.enabled = active;
    }
}