using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject[] prefab;
        public int size;
    }
    public static carPooler instance;

    private void Awake()
    {
        instance = this;

    }

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                int randomCar = Random.Range(0, 2);
                GameObject obj = Instantiate(pool.prefab[randomCar]);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation, string SpawnLane)
    {

        if (!poolDictionary.ContainsKey(tag))
        {
            return null;
        }


        GameObject objectToSpawn = poolDictionary[tag].Dequeue();
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        IPooledObject pooledObj = objectToSpawn.GetComponent<IPooledObject>();

        if(pooledObj != null)
        {
            pooledObj.OnObjectSpawn(SpawnLane);
        }

        poolDictionary[tag].Enqueue(objectToSpawn);
        return objectToSpawn;
    }


}

