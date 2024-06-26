using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fairy : MonoBehaviour
{
    void selfDestruct(){
        Destroy(this.gameObject);
    }

    public Vector2 flyVelocity;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("selfDestruct", Random.Range(1.0f,2.5f));
    }

    // Update is called once per frame
    void Update()
    {
        // move fairy only when game is not paused (timeScale)
        this.transform.Translate(flyVelocity * Time.timeScale);
    }
}
