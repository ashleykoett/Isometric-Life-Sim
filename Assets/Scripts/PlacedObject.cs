using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacedObject : MonoBehaviour
{
    public LayerMask floorLayerMask;
    private bool _placed = false;

    void Start()
    {
        AttemptPlacement();
    }


    /** 
     * This currently only works for an object that takes up one tile
     */
    private void AttemptPlacement()
    {
        Vector3 bounds = (gameObject.GetComponent<Collider>().bounds.size / 2);
        Collider[] hitColliders = Physics.OverlapBox(gameObject.transform.position, bounds, Quaternion.identity, floorLayerMask);
        for(int i=0;i<hitColliders.Length;i++)
        {
            var hit = hitColliders[i].gameObject;
            Tile tile = hit.GetComponent<Tile>();
            if(tile)
            {
                if(!tile.Occupied)
                {
                    Place(tile);
                }
            }
        }

        Debug.Log("Cannot place object here");
    }

    private void Place(Tile tile)
    {
        _placed = true;
        tile.Occupied = true;
        Debug.Log("Object placed on tile.");
    }
}
