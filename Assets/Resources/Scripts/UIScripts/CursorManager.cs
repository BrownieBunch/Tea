using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//this is a very simple script that is assigned to a empty GameObject and is used in every scene to change the cursor...
//It has public methods so as to be called from scripts and button components.
public class CursorManager: MonoBehaviour
{
    [SerializeField]
    Texture2D simpleCursor;
    [SerializeField]
    Texture2D specialCursor;

    Vector2 hotspot;
   
    // Start is called before the first frame update
    void Start()
    {
        //clean reset from previous state
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

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

}
