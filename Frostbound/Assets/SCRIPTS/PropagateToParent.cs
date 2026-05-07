using UnityEngine;
using NarrationsJouables;

public class PropagateToParent : MonoBehaviour, IObservable
{
    private ActionableItem parentActionable;

    void Awake()
    {
        parentActionable = GetComponentInParent<ActionableItem>();
    }

    public bool ObservationStateChanged(bool _observed, float _distance = -1)
    {
        if (parentActionable != null)
            return parentActionable.ObservationStateChanged(_observed, _distance);
        return false;
    }
}