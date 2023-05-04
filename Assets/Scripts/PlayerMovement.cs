using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;

    private Vector3 _targetPosition;
    private bool _targetSelected = false;
    private Vector3 velocity = Vector3.zero;

    private float _timer = 0f;

    // Update is called once per frame
    void Update()
    {
        if(_targetSelected == false) { 
            return;
        }

        if(Vector3.Distance(transform.position,_targetPosition) < 0.001f)
        {
            transform.position = _targetPosition;
            _targetSelected = false;
            return;
        }

        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, speed * Time.deltaTime);
    }

    public void SetTarget(Transform target)
    {
        _targetSelected = true;

        // Since the game is effectively 2D, I'm keeping the Y position always the same

        _targetPosition = new Vector3(target.position.x, transform.position.y, target.position.z);
        transform.LookAt(new Vector3(target.position.x,transform.position.y,target.position.z));
    }
}
