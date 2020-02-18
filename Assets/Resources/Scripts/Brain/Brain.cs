using System;
using System.Collections;
using System.Collections.Generic;
using Resources.Scripts.Interaction;
using Unity.Mathematics;
using UnityEngine;

public class Brain : MonoBehaviour
{
    private int startingHealth;
    public int Health { get; private set; }
    public int BaseMinuetsBeforeDeath = 15;
    public bool DoHealthDecay = true;
    public BrainState State = BrainState.Asleep; 
    public int StateProgress = 0;

    private void Start()
    {
        var baseSecondsBeforeDeath = BaseMinuetsBeforeDeath * 60;
        startingHealth = baseSecondsBeforeDeath;
        Health = baseSecondsBeforeDeath;
        InvokeRepeating("HealthDecay", 0, 1); //Runs every 1 second
    }

    private void HealthDecay()
    {
        if (!DoHealthDecay) { return; }
        if (Health == 0)
        {
            State = BrainState.Dead;
            return;
        }
        Health--;
    }

    public int GetHealthPercent()
    {
        return (int)math.floor((Health * 100) / startingHealth);
    }

    public void AddSecondsToHealth(int seconds)
    {
        Health += seconds;
    }


}
