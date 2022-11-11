using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] Cannon cannonPrefab;
    
    [SerializeField] bool isPlacable;
    public bool IsPlacable { get { return isPlacable; } }

    void OnMouseDown()
    {
        if (isPlacable)
        {
            bool isPlaced = cannonPrefab.CreateCannon(cannonPrefab, transform.position);
            isPlacable = !isPlaced;
        }
    }
    
}
