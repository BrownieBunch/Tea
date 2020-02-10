using UnityEngine;
using System.Collections;

public class TogglePauseFeature : MonoBehaviour
{
    bool isPaused;
    public GameObject PauseScreen;

    //to keep an overview of input keys and not search through scripts
    KeyCode pauseGameKey = KeyMap.pauseGameKey;

    GameStateManager gameStateManager;

    void Awake()
    {
        gameStateManager = FindObjectOfType<GameStateManager>();

        if (PauseScreen == null)
        { 
        PauseScreen = GameObject.Find("PauseScreen");
        }
    }

    void Update()
    {
        EnableTogglePause();
    }


    void PauseGame()
    {
        Time.timeScale = 0;
        PauseScreen.SetActive(true);
        isPaused = true;

        if (gameStateManager != null)
        {
            gameStateManager.TogglePause(true);
            Debug.Log("Game is now paused.");
        }
    }

    public void UnPauseGame()
    {
        Time.timeScale = 1;
        PauseScreen.SetActive(false);
        isPaused = false;
        if (gameStateManager != null)
        {
            gameStateManager.TogglePause(false);
            Debug.Log("Game is now unpaused.");
        }
    }

    void TogglePause()
    {
        if (!isPaused)
        {
            PauseGame();
        }
        else
        {
            UnPauseGame();
        }
    }

    void EnableTogglePause()
    {
        //nope, this works like shit> 
        //   if (Input.GetAxisRaw("TogglePause") == 1)
       if (Input.GetKeyDown(pauseGameKey))
        { TogglePause(); }
    }
}
