using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject goblingPrefab;
    [SerializeField] int poolSize = 5;
    [SerializeField] float spawnTime;

    GameObject[] pool;

    void Awake()
    {
        PopulatePool();        
    }

    void PopulatePool()
    {
        pool = new GameObject[poolSize];

        for(int i = 0; i < pool.Length ; i++)
        {
            pool[i] = Instantiate(goblingPrefab, transform);
            pool[i].SetActive(false);
        }
    }

    void Start()
    {
        StartCoroutine(SpawnGoblin());
    }

    IEnumerator SpawnGoblin()
    {
        while(true)
        {
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
