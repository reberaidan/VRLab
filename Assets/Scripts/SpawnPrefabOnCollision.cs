using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPrefabOnCollision : MonoBehaviour
{
    public GameObject prefabToSpawn; // The prefab we want to spawn
    public Transform spawnPoint; // The point where we want to spawn the prefab

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Equipment"))
        {
            // Instantiate the prefab at the specified spawn point
            Instantiate(prefabToSpawn, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
