using System.Collections.Generic;
using UnityEngine;

public class PlatformPool : MonoBehaviour
{
    public GameObject platformPrefab;
    public int poolSize = 5;
    private Queue<GameObject> platformPool = new Queue<GameObject>();

    void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject platform = Instantiate(platformPrefab);
            platform.SetActive(false);
            platformPool.Enqueue(platform);
        }
    }

    public GameObject GetPlatform(Vector3 position)
    {
        if (platformPool.Count > 0)
        {
            GameObject platform = platformPool.Dequeue();
            platform.transform.position = position;
            platform.SetActive(true);
            return platform;
        }
        else
        {
            GameObject newPlatform = Instantiate(platformPrefab, position, Quaternion.identity);
            return newPlatform;
        }
    }

    public void ReturnPlatform(GameObject platform)
    {
        platform.SetActive(false);
        platformPool.Enqueue(platform);
    }
}
