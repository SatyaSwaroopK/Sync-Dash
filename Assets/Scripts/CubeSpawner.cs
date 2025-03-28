using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public ObjectPool objectPool;  
    public float spawnInterval = 2f;  
    public Transform playerSpawnPoint;
    public Transform ghostSpawnPoint;
    public float ypos;
    void Start()
    {
        InvokeRepeating(nameof(SpawnCubes), 1f, spawnInterval);
    }

    void SpawnCubes()
    {
        Vector3 playerPos = new Vector3(playerSpawnPoint.position.x, ypos, playerSpawnPoint.position.z);
        Vector3 ghostPos = new Vector3(ghostSpawnPoint.position.x, ypos, ghostSpawnPoint.position.z);
        GameObject playerCube = objectPool.GetCube(playerPos);

       
        GameObject ghostCube = objectPool.GetCube(ghostPos);
        
         StartCoroutine(ReturnToPool(playerCube, 5f));
        StartCoroutine(ReturnToPool(ghostCube, 5f));
    }

    System.Collections.IEnumerator ReturnToPool(GameObject cube, float delay)
    {
        yield return new WaitForSeconds(delay);
        objectPool.ReturnCube(cube);
    }
}
