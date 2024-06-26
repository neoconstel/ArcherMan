using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;


public class Game : MonoBehaviour
{
    // public variables in inspector
    public GameObject greenBaloon;
    public GameObject redBaloon;
    public GameObject yellowBaloon;
    public GameObject purpleBaloon;
    public Transform baloonOrigin;
    public float baloonSpawnInterval;
    public TMP_Text scoreText;
    public TMP_Text highScoreText;
    public int green_hit_points;
    public int yellow_hit_points;
    public int green_miss_penalty;
    public int red_hit_penalty;    
    public int purple_hit_penalty;
    


    // hidden public variables
    [HideInInspector]
    public int score = 0;


    // private variables
    float nextBaloonSpawnTime = 0f;
    int highScore;

    void spawnBaloon(){
        if(Time.time >= nextBaloonSpawnTime){
            GameObject randomBaloon;

            float randomNumber = Random.Range(-15.0f, 40.0f);
            if(randomNumber < 11)
                randomBaloon = greenBaloon;
            else if(randomNumber < 21)
                randomBaloon = redBaloon;
            else if(randomNumber < 31)
                randomBaloon = yellowBaloon;
            else
                randomBaloon = purpleBaloon;

            Instantiate(randomBaloon, baloonOrigin.position, Quaternion.identity);

            nextBaloonSpawnTime = nextBaloonSpawnTime = Time.time + baloonSpawnInterval;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetInt("highScore", 0);
        highScoreText.text = "Best: " + highScore;
    }

    // Update is called once per frame
    void Update()
    {
        spawnBaloon();

        scoreText.text = "Score: " + score;

        if(score >= highScore){
            highScore = score;
            PlayerPrefs.SetInt("highScore", score);

            highScoreText.text = "Best: " + score;
        }
    }
}
