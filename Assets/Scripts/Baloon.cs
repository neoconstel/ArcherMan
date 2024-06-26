using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baloon : MonoBehaviour
{

    public float speed;
    public bool enableRandomSpeedMultiplier;
    public GameObject baloonItem;

    Game game;
    AudioSource[] sounds;

    void playSound(string audioClipName){
        for(int i = 0; i < sounds.Length; i++){
            if(sounds[i].clip.name == audioClipName){
                sounds[i].Play();
                break;
            }
        }
    }

    public void beforeDestroyByObjectKiler(){
        // call this method before destroying this object by object killer (baloons not hit by arrow)
        if(gameObject.tag == "green_baloon")
        {
            // play sound
            playSound("electric_zap");

            game.score -= game.green_miss_penalty; // subtract points for missing this baloon
            if(game.score < 0)
                game.score = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.tag == "arrow"){

            // activate any item baloon carries
            if(baloonItem){
                Instantiate(baloonItem, this.transform.position, Quaternion.identity);
            }

            // score awarding/deduction
            if(gameObject.tag == "green_baloon"){
                game.score += game.green_hit_points;

                // play sound
                playSound("baloon_pop");
            }
            else if(gameObject.tag == "red_baloon"){
                game.score -= game.red_hit_penalty;

                // play sound
                playSound("baloon_pop");
            }
            else if(gameObject.tag == "yellow_baloon"){
                game.score += game.yellow_hit_points;

                // play sound
                playSound("magic_wand");
            }
            else if(gameObject.tag == "purple_baloon"){
                game.score -= game.purple_hit_penalty;

                // play sound
                playSound("explosion");
            }

            if (game.score < 0)
                game.score = 0;

            Destroy(this.gameObject);
        }
    }    

    // Start is called before the first frame update
    void Start()
    {
        game = GameObject.Find("GAME_LOGIC").GetComponent<Game>();
        sounds = GameObject.Find("GAME_SOUND").GetComponents<AudioSource>();

        // random additional speed percentage
        if (enableRandomSpeedMultiplier){
            float randomSpeedMultiplier = Random.Range(1.0f, 1.3f);
            speed *= randomSpeedMultiplier;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // move baloons only when game is not paused (timeScale)
        this.transform.Translate(Vector2.up * speed * Time.timeScale);
    }
}
