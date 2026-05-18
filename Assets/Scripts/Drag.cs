using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// NOTE: there must be a collider on the object in order for the mouse/touch events to work
public class Drag : MonoBehaviour
{
    public bool xLock;
    public bool yLock;
    public bool zLock;
    public bool zeroTimeScaleLock; // for disable drag if timeScale = 0
    Vector3 difference = Vector3.zero;

    private bool isDragging = false;

    private Vector2 GetInputPosition()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.isPressed)
            return Touchscreen.current.primaryTouch.position.ReadValue();
        return Vector2.zero;
#else
        if (Mouse.current != null)
            return Mouse.current.position.ReadValue();
        return Vector2.zero;
#endif
    }

    void OnMouseDown()
    {
        if (!enabled) return;
        if (!zeroTimeScaleLock || Time.timeScale != 0)
        {
            Vector2 inputPos = GetInputPosition();
            difference = Camera.main.ScreenToWorldPoint(inputPos) - transform.position;
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
        if (!enabled) return;

        if (!zeroTimeScaleLock || Time.timeScale != 0)
        {
            Vector2 inputPos = GetInputPosition();

            Vector3 oldPosition = transform.position;
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(inputPos) - difference;

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
