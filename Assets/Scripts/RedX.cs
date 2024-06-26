using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedX : MonoBehaviour
{
    void selfDestruct(){
        Destroy(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        Invoke("selfDestruct", 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
