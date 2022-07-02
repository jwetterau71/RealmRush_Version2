using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class CoordinateLabeler : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.gray;
    [SerializeField] Color exploredColor = Color.yellow;
    [SerializeField] Color pathColor = new Color(1f, .5f, 0f);

    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int(); 
    GridManager gridManager;

    private void Awake()
    {
        label = GetComponent<TextMeshPro>();
        label.enabled = false;        
        gridManager = FindObjectOfType<GridManager>();
        DisplayCoordinates();
    }
    void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
            label.enabled = true;
        }

        SetLabelColor();
        ToggleLabels();
    }

    void DisplayCoordinates()
    {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);
        label.text = $"{coordinates.x},{coordinates.y}";
    }

    void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }

    void SetLabelColor()
    {        
        if (gridManager == null) return;
        Node node = gridManager.GetNode(coordinates);        

        if (node == null) return;        

        label.color = colorDecider(node);        
    }

    Color colorDecider(Node node)
    {  
        if (!node.isWalkable)
        {
            return blockedColor;
        }
        else if (node.isPath)
        {
            return pathColor;
        }
        else if (node.isExplored)
        {
            return exploredColor;
        }
        else
        {
            return defaultColor;
        }
    }

    void ToggleLabels()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            label.enabled=!label.IsActive();
        }
    }
}
