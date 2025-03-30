using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleSpawner : MonoBehaviour
{
        public GameObject collectiblePrefab;
        public float      spawnRate    = 2f;
        public float      spawnRadius  = 5f;
        public float      spawnYOffset = 0f;

        private float nextSpawnTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            if (Time.time >= nextSpawnTime)
            {
                    SpawnCollectible();
                    nextSpawnTime = Time.time + 1f / spawnRate;
            }
    }

    void SpawnCollectible()
    {
            float   randomX       = Random.Range(-spawnRadius, spawnRadius);
            float   randomZ       = Random.Range(-spawnRadius, spawnRadius);
            Vector3 spawnPosition = transform.position + new Vector3(randomX, spawnYOffset, randomZ);

            if (collectiblePrefab != null)
            {
                    Instantiate(collectiblePrefab, spawnPosition, Quaternion.identity);
            }
            else
            {
                    Debug.LogError("Collectible Prefab is not assigned to the Spawner!");
            }
    }
}
