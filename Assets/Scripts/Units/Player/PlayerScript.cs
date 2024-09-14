using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerScript : MonoBehaviour
{
    Camera _mainCamera;
    private GameObject _selectedObject;
    // Start is called before the first frame update
    void Start()
    {
         _mainCamera = Camera.main;
    }

    private void Update()
    {
        
    }

    void HandleMouseClick()
    {
        Vector2 mousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        if (_selectedObject == null)
        {
            if (hit.collider != null && hit.transform.CompareTag("Moveable"))
            {
                _selectedObject = hit.transform.gameObject;
            }
        }
        else
        {
            if (hit.collider != null)
            {
                _selectedObject.transform.position = mousePosition;
                _selectedObject = null;
            }
        }
    }

    void OnMouseDown()
    {
        HandleMouseClick();
    }
}
