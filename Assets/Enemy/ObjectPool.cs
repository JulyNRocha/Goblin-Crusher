using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject goblingPrefab;
    [SerializeField] float spawnTime;

    
    void Start()
    {
        StartCoroutine(SpawnGoblin());
    }

    IEnumerator SpawnGoblin()
    {
        while(true)
        {
            Instantiate(goblingPrefab, transform);
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
