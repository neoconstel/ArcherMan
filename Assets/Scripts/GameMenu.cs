using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public GameObject gameMenu;
    public GameObject pauseButton;


    [HideInInspector]
    public void pauseGame(){
        Time.timeScale = 0;
        pauseButton.SetActive(false);
        gameMenu.SetActive(true);
    }

    [HideInInspector]
    public void resumeGame(){
        Time.timeScale = 1;
        pauseButton.SetActive(true);
        gameMenu.SetActive(false);
    }

    [HideInInspector]
    public void returnToMainScreen(){
        // timeScale is preserved between scene changes. Do this now in case user returns to game from main screen
        Time.timeScale = 1;
        
        SceneManager.LoadScene(0);
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
