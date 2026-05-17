using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Archer : MonoBehaviour
{

    public Game game;
    public Transform arrowOrigin;
    public GameObject arrow;
    public float fireInterval;

    Vector3 archerPositionAtBowPull;


    void Fire()
    {
        Instantiate(arrow, arrowOrigin.position, Quaternion.identity);
    }

    public void OnMouseDown()
    {
        archerPositionAtBowPull = transform.position;
    }

    public void OnMouseUp()
    {
        if (transform.position == archerPositionAtBowPull && Time.timeScale != 0)
        {
            Fire();
        }
    }


    void Start()
    {

    }

    void Update()
    {

    }
}
