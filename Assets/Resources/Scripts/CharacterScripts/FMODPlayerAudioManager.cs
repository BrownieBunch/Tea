using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FMODPlayerAudioManager : MonoBehaviour
{
    private MovementController mc;
    
    [FMODUnity.EventRef]
    public string WalkingGeneric;
    public float WalkingLengthSeconds = 5.6f;


    private float walkingTimer;
    
    private void Start()
    {
        mc = GetComponentInParent<MovementController>();
        if (mc == null)
        {
            Debug.Log("FMOD Player Audio Manager could not find the movement controller!");
        }

        walkingTimer = WalkingLengthSeconds;
    }

    private void Update()
    {
        if (!mc.isWalking)
        {
            return;
        }
        
        if (walkingTimer >= WalkingLengthSeconds)
        {
            FMODUnity.RuntimeManager.PlayOneShot( WalkingGeneric );
            walkingTimer = 0.0f;
        }

        walkingTimer += Time.deltaTime;
    }
}
