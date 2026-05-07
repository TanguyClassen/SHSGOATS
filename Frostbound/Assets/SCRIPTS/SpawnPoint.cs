using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public string pointName;

    void Start()
    {
        string target = PlayerPrefs.GetString("SpawnPoint", "");
        if (target == pointName)
        {
            // Téléporte le joueur ici
            GameObject player = GameObject.FindWithTag("Player");
            if (player != null)
                player.transform.position = transform.position;
        }
    }
}