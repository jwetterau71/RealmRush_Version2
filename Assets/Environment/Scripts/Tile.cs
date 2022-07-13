using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{    
    [SerializeField] Tower towerPrefab;

    [SerializeField] bool isPlaceable;
    public bool IsPlaceable { get { return isPlaceable; } }
    Vector2Int coordinates = new Vector2Int();

    GridManager gridManager;
    Pathfinder pathFinder;

    private void Awake()
    {        
        gridManager = FindObjectOfType<GridManager>();
        pathFinder = FindObjectOfType<Pathfinder>();

        if (gridManager != null)
        {
            coordinates = gridManager.GetCoordinatesFromPosition(transform.position);
            if (!isPlaceable)
            {                
                gridManager.BlockNode(coordinates);
            }
        }
    }

    void Start()
    {

    }

    private void OnMouseDown()
    {
        if (gridManager.GetNode(coordinates).isWalkable && !pathFinder.WillBlockPath(coordinates))
        {
            bool isSuccessful = towerPrefab.CreateTower(towerPrefab, transform.position);
            if (isSuccessful)
            {                
                gridManager.BlockNode(coordinates);
                pathFinder.NotifyReceivers();
            }
        }
    }    
}
