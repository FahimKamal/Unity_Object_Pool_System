using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject cubePrefab;

    private void FixedUpdate()
    {
        Instantiate(cubePrefab, transform.position, Quaternion.identity);
    }
}
