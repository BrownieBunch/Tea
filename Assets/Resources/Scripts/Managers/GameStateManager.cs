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

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
