using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlayTile : MonoBehaviour
{
    public Material canSelectMaterial;
    public Material cannotSelectMaterial;

    public void ShowTile()
    {
        gameObject.GetComponent<Renderer>().enabled = true;
    }

    public void HideTile()
    {
        gameObject.GetComponent<Renderer>().enabled = false;
    }

    public void BadSelection()
    {
        gameObject.GetComponent<Renderer>().material = cannotSelectMaterial;
    }

    public void GoodSelection()
    {
        gameObject.GetComponent<Renderer>().material = canSelectMaterial;
    }

}
