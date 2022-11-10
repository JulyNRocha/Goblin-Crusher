using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] GameObject cannonPrefab;
    [SerializeField] bool isPlacable;

    void OnMouseDown()
    {
        if (isPlacable)
        {
            Instantiate(cannonPrefab, transform.position, Quaternion.identity);
            Debug.Log(transform.name);
        }
    }
    
}
