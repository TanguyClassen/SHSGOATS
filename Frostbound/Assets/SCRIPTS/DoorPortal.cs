using UnityEngine;

public class DoorPortal : MonoBehaviour
{
    public string targetScene; // nom de la scène cible
    public string spawnPointName; // nom du spawn point dans la scène cible

    public void Enter()
    {
        PlayerPrefs.SetString("SpawnPoint", spawnPointName);
        SceneTransition.instance.GoToScene(targetScene);
    }
}