using UnityEngine;
using System.Collections;

public class PlatformSpawner : MonoBehaviour
{
    public PlatformPool platformPool;
    public Transform player;
    public float spawnDistance = 10f; 
    public float platformLength = 10f;
    private Vector3 nextSpawnPosition;

    void Start()
    {
        nextSpawnPosition = new Vector3(0, 0, spawnDistance);
        for (int i = 0; i < 5; i++)
        {
            SpawnPlatform();
        }
    }

    void Update()
    {
        if (player.position.z > nextSpawnPosition.z - (spawnDistance * 2))
        {
            SpawnPlatform();
        }
    }

    void SpawnPlatform()
    {
        GameObject platform = platformPool.GetPlatform(nextSpawnPosition);
        nextSpawnPosition.z += platformLength;
       
        StartCoroutine(ReturnPlatformToPool(platform, 10f));
    }

    IEnumerator ReturnPlatformToPool(GameObject platform, float delay)
    {
        yield return new WaitForSeconds(delay);
        platformPool.ReturnPlatform(platform);
    }
}
