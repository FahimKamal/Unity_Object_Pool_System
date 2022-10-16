using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    #region Simple code that spawns objects using instantiate method

    // [SerializeField] private GameObject cubePrefab;
    //
    // private void FixedUpdate()
    // {
    //     Instantiate(cubePrefab, transform.position, Quaternion.identity);
    // }

    #endregion
    
    private ObjectPooler objectPooler;

    private void Start()
    {
        objectPooler = ObjectPooler.Instance;
    }

    private void FixedUpdate()
    {
        objectPooler.SpawnFromPool("Cube", transform.position, Quaternion.identity);
    }
}
