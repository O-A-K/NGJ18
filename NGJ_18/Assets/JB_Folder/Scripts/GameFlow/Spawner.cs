using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    public static Spawner spawner;

    public SpawnPoint spawnPointPlayerOne;
    public SpawnPoint spawnPointPlayerTwo;

    void OnEnable()
    {
        if (spawner)
        {
            Destroy(this.gameObject);
        }
        else
        {
            spawner = this;
        }

    }
}
