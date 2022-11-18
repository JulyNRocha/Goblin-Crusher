using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] Cannon cannonPrefab;
    
    [SerializeField] bool isPlacable;
    public bool IsPlacable { get { return isPlacable; } }

    GridManager gridManager;
    Vector2Int coordinates = new Vector2Int();

    void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
    }

    void Start()
    {
        if ( gridManager != null)
        {
            coordinates = gridManager.GetCoordinatesFromPosition(transform.position);

            if(!isPlacable)
            {
                gridManager.BlockNode(coordinates);
            }
        }
    }

    void OnMouseDown()
    {
        if (isPlacable)
        {
            bool isPlaced = cannonPrefab.CreateCannon(cannonPrefab, transform.position);
            isPlacable = !isPlaced;
        }
    }
    
}
