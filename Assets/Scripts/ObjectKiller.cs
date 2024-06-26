using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectKiller : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Player")
            return;

        Baloon baloon = col.GetComponent<Baloon>();
        if(baloon)
            baloon.beforeDestroyByObjectKiler();
  
        Destroy(col.gameObject);
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
