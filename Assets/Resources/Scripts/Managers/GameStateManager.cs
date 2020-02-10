using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class GameStateManager : MonoBehaviour
{
    //generic events
    public event Action GamePausedEvent;
    public event Action GameUnPausedEvent;
    public event Action GameEndedEvent;
    public event Action GameReloadEvent;

    //project specific events
    public event Action BrownieDeathEvent;



    void Awake()
    {
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void TogglePause(bool PausedOrNot)
    {
        if (PausedOrNot)
        { 
        if (GamePausedEvent != null)
        { GamePausedEvent(); }
        }
    else
        {
            if (GameUnPausedEvent != null)
            { GameUnPausedEvent(); }
        }
    }
  
}
