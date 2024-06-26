using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// NOTE: there must be a collider on the object in order for the mouse events to work
public class Drag : MonoBehaviour
{
    public bool xLock;
    public bool yLock;
    public bool zLock;
    public bool zeroTimeScaleLock; // for disable drag if timeScale = 0
    Vector3 difference = Vector3.zero;

    void OnMouseDown(){
        if(!zeroTimeScaleLock || Time.timeScale != 0)
            difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
    }

    void OnMouseDrag(){
        if(!zeroTimeScaleLock || Time.timeScale != 0){
            Vector3 oldPosition = transform.position;
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - difference;
            if(xLock)
                newPosition.x = oldPosition.x;
            if(yLock)
                newPosition.y = oldPosition.y;
            if(zLock)
                newPosition.z = oldPosition.z;

            transform.position = newPosition;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
