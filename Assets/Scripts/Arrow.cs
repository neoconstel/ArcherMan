using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // move arrow only when game is not paused (timeScale)
        this.transform.Translate(Vector2.right * speed * Time.timeScale);
    }
}
