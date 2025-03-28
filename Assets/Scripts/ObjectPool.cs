using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject cubePrefab;  
    public int poolSize = 10;
    private Queue<GameObject> cubePool = new Queue<GameObject>();

    void Start()
    {
       
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(cubePrefab);
            obj.SetActive(false);
            cubePool.Enqueue(obj);
        }
    }

    public GameObject GetCube(Vector3 position)
    {
        if (cubePool.Count > 0)
        {
            GameObject obj = cubePool.Dequeue();
            obj.transform.position = position;
            obj.SetActive(true);
            return obj;
        }
        else
        {           
            GameObject obj = Instantiate(cubePrefab, position, Quaternion.identity);
            return obj;
        }
    }

    public void ReturnCube(GameObject obj)
    {
        obj.SetActive(false);
        cubePool.Enqueue(obj);
    }
}
