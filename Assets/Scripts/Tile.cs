using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private bool _occupied = false;
    public bool Occupied
    {
        get { return _occupied; }
        set { _occupied = value; }
    }
}
