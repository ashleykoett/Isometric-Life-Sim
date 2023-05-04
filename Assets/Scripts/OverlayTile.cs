using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlayTile : MonoBehaviour
{
    public void ShowTile()
    {
        gameObject.GetComponent<Renderer>().enabled = true;
    }

    public void HideTile()
    {
        gameObject.GetComponent<Renderer>().enabled = false;
    }

}
