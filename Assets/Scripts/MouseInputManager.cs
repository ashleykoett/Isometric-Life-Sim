using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Layers
{
    Selectable = 6,
    Interactable = 7,
}

public class MouseInputManager : MonoBehaviour
{
    private static MouseInputManager _instance;
    public static MouseInputManager Instance {  get { return _instance; } }

    public PlayerMovement player;
    public OverlayTile overlayTile;
    public float overlayTileOffsetY = 1f;

    private GameObject _selectedObject;

    // Singleton
    private void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else
        {
            _instance = this;
        }
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        int layerMask = 1 << (int)Layers.Selectable;

        if(Physics.Raycast(ray, out hit, Mathf.Infinity, (int) layerMask))
        {
            _selectedObject = hit.collider.gameObject;
            Vector3 targetPosition = _selectedObject.transform.position;
            overlayTile.transform.position = new Vector3(targetPosition.x, targetPosition.y + overlayTileOffsetY, targetPosition.z);
            overlayTile.ShowTile();

            if(Input.GetMouseButtonDown(0))
            {
                player.SetTarget(_selectedObject.transform);
            }

            return;
        }
        else
        {
            overlayTile.HideTile();
        }
    }

}
