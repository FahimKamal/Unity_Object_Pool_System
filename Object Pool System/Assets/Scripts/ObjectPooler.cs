using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ObjectPooler : MonoBehaviour
{
    #region Singleton

    public static ObjectPooler Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion

    [Serializable]
    public class Pool
    {
        /// <summary> Name of the Object in the pool. </summary>
        public string tag;
        
        /// <summary> Prefab of the Object in the pool. </summary>
        public GameObject prefab;
        
        /// <summary> Max Size of the object that will instantiate in scene pool. </summary>
        public int size;
    }
    
    [SerializeField] private List<Pool> pools;
    
    public Dictionary<string, Queue<GameObject>> PoolDictionary;

    // Start is called before the first frame update
    private void Start()
    {
        PoolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (var pool in pools)
        {
            var objectPool = new Queue<GameObject>();
            
            for (var i = 0; i < pool.size; i++)
            {
                var obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            
            PoolDictionary.Add(pool.tag, objectPool);
        }
    }
    
    /// <summary>
    /// Spawn an object from the pool
    /// </summary>
    /// <param name="objectTag">Name of the object.</param>
    /// <param name="position">Position where the object will spawn.</param>
    /// <param name="rotation">Rotation of the object while spawning.</param>
    /// <returns></returns>
    public GameObject SpawnFromPool(string objectTag, Vector3 position, Quaternion rotation)
    {
        if (!PoolDictionary.ContainsKey(objectTag))
        {
            Debug.LogWarning("Pool with tag " + objectTag + " doesn't exist.");
            return null;
        }
        
        var objectToSpawn = PoolDictionary[objectTag].Dequeue();
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;
        
        PoolDictionary[objectTag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }
}
