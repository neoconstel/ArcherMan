using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : MonoBehaviour
{

    public Game game;
    public Transform arrowOrigin;
    public GameObject arrow;
    public float fireInterval;

    float nextFireTime = 0f; // for autoFire() method
    Vector3 archerPositionAtBowPull;


    void fire(){
        Instantiate(arrow, arrowOrigin.position, Quaternion.identity);
    }

    void OnMouseDown(){
        archerPositionAtBowPull = transform.position;
    }

    void OnMouseUp(){
        // if archer has not been dragged after clicking, then release arrow
        if(transform.position == archerPositionAtBowPull && Time.timeScale != 0){
            fire();
        }
    }

    void autoFire(){
        // fires continuously when method is called in Update()

        if (Time.time >= nextFireTime){
            Instantiate(arrow, arrowOrigin.position, Quaternion.identity);
            nextFireTime = Time.time + fireInterval;
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
