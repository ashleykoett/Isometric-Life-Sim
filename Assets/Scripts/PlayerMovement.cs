using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public Bounds surroundingTileBounds;
    public LayerMask tileLayerMask;

    private GameObject _finalTarget;

    private GameObject _currentTarget;
    private Vector3 _currentTargetPosition;
    private bool _targetSelected = false;

    private void Start()
    {
        surroundingTileBounds.center = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(_targetSelected == false) { 
            return;
        }

        if(Vector3.Distance(transform.position,_currentTargetPosition) < 0.001f)
        {
            transform.position = _currentTargetPosition;
            if(_currentTargetPosition == _finalTarget.transform.position)
            {
                return;
            }

            GetNextTileTarget();
        }

        transform.position = Vector3.MoveTowards(transform.position, _currentTargetPosition, speed * Time.deltaTime);
    }

    public void SetTarget(GameObject target)
    {
        _targetSelected = true;

        // Since the game is effectively 2D, I'm keeping the Y position always the same
        _finalTarget = target;
        GetNextTileTarget();
        // _targetPosition = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
        // transform.LookAt(new Vector3(target.transform.position.x,transform.position.y,target.transform.position.z));
    }

    private void GetNextTileTarget()
    {
        Collider[] tiles = Physics.OverlapBox(transform.position, surroundingTileBounds.size/2, Quaternion.identity, tileLayerMask);
        float closestDistance = 9999f;
        for(int i=0;i<tiles.Length;i++)
        {
            float currentDistance = Vector3.Distance(tiles[i].transform.position, _finalTarget.transform.position);
            if ( currentDistance < closestDistance && !tiles[i].GetComponent<Tile>().Occupied)
            {
                closestDistance = currentDistance;
                _currentTarget = tiles[i].gameObject;
            }
        }

        _currentTargetPosition = new Vector3(_currentTarget.transform.position.x, transform.position.y, _currentTarget.transform.position.z);
        transform.LookAt(new Vector3(_currentTarget.transform.position.x, transform.position.y, _currentTarget.transform.position.z));
    }
}
