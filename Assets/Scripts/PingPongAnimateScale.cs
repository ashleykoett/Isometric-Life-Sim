using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPongAnimateScale : MonoBehaviour
{
    public float rate;
    public float minScale;
    public float maxScale;

    public Transform thisTransform;
    // Start is called before the first frame update
    void Start()
    {
        if(thisTransform == null)
        {
            thisTransform = transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        PingPong();
    }

    void PingPong()
    {
        this.transform.localScale = (minScale + Mathf.PingPong(Time.time * rate, maxScale-minScale))*Vector3.one;
    }
}
