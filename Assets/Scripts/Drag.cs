using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// NOTE: there must be a collider on the object in order for the mouse events to work
public class Drag : MonoBehaviour
{
    public bool xLock;
    public bool yLock;
    public bool zLock;
    public bool zeroTimeScaleLock; // for disable drag if timeScale = 0
    Vector3 difference = Vector3.zero;

    private bool isDragging = false;

    void OnMouseDown()
    {
        if (!enabled) return; // respect disabled state
        if (!zeroTimeScaleLock || Time.timeScale != 0)
        {
            Vector2 mousePos = Mouse.current.position.ReadValue();
            difference = Camera.main.ScreenToWorldPoint(mousePos) - transform.position;
            isDragging = true;
        }
    }

    void OnMouseUp()
    {
        isDragging = false;
    }

    void Update()
    {
        if (!isDragging) return;
        if (!enabled) return; // respect disabled state

        if (!zeroTimeScaleLock || Time.timeScale != 0)
        {
            Vector2 mousePos = Mouse.current.position.ReadValue();

            Vector3 oldPosition = transform.position;
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(mousePos) - difference;

            if (xLock)
                newPosition.x = oldPosition.x;
            if (yLock)
                newPosition.y = oldPosition.y;
            if (zLock)
                newPosition.z = oldPosition.z;

            transform.position = newPosition;
        }
    }
}
