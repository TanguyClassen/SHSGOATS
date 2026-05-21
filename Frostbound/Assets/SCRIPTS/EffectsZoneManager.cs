using UnityEngine;
using UnityEngine.VFX;

public class EffectsZoneManager : MonoBehaviour
{
    public GameObject[] effectsToDisable; // neige, blizzard, etc

    public void EnterZone()
    {
        foreach (GameObject effect in effectsToDisable)
            effect.SetActive(false);
    }

    public void ExitZone()
    {
        foreach (GameObject effect in effectsToDisable)
            effect.SetActive(true);
    }
}