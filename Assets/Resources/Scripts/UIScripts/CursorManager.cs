using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//this is a very simple script that is assigned to a empty GameObject and is used in every scene to change the cursor...
//It has public methods so as to be called from scripts and button components.
public class CursorManager: MonoBehaviour
{

    GameStateManager gameStateManager;

    [SerializeField]
    Texture2D simpleCursor;
    [SerializeField]
    Texture2D specialCursor;

    Vector2 hotspot;

    private void Awake()
    {
        gameStateManager = FindObjectOfType<GameStateManager>();
        if (gameStateManager != null)
        {
            if (SceneManager.GetActiveScene().buildIndex != 0)
            {
                gameStateManager.GamePausedEvent += ShowCursor;
                gameStateManager.GameUnPausedEvent += HideCursor;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //clean reset from previous state
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            ShowCursor();
        }
        else
        { HideCursor(); }

        //this is the default cursor: 
        SimpleCursor();
    }

    public void SimpleCursor()
    {
        //Debug.Log("SimpleCursor");
        hotspot = new Vector2(simpleCursor.width - 1, 0);
        Cursor.SetCursor(simpleCursor, hotspot, CursorMode.Auto);
    }

    public void SpecialCursor()
    {
       // Debug.Log("SpecialCursor");
        hotspot = new Vector2(specialCursor.width - 1, 0);
        Cursor.SetCursor(specialCursor, hotspot, CursorMode.Auto);
    }

    void ShowCursor()
    {
        Cursor.lockState  = CursorLockMode.None;
        Cursor.visible = true;
    }

    void HideCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Debug.Log("Cursor hidden.");
    }

}
