using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject goblingPrefab;
    [SerializeField] int poolSize = 5;
    [SerializeField] float spawnTime = 1f;

    GameObject[] pool;

    void Awake()
    {
        PopulatePool();        
    }

    void Start()
    {
        StartCoroutine(SpawnGoblin());
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

    IEnumerator SpawnGoblin()
    {
        while(true)
        {
            EnabledObjectInPool();
            yield return new WaitForSeconds(spawnTime);
        }
    }

    void EnabledObjectInPool()
    {
        foreach(GameObject enemy in pool)
        {
            if (!enemy.activeInHierarchy)
            {
                enemy.SetActive(true);
                return;
            }
        }
    }
}
