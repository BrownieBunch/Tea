using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script controls movement of player in first person/3D mode.

// Walking speed. Running Speed. Should running be shift + navigationals? 
// Smooth transitions with GetAxis Raw and then Lerping? 


public class FPMovement : CharacterControllerLocalVS
{

    public bool isWalking;
    public bool isRunning;

    LevitateBehaviour levitateBehaviour;
    JumpBehaviour jumpBehaviour;
    public override void Awake()
    {
        base.Awake();
        levitateBehaviour = GetComponent<LevitateBehaviour>();
        jumpBehaviour = GetComponent<JumpBehaviour>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if ((canMove) && (!levitateBehaviour.islevitating))
        { MoveOnLookAxis(); }
    }

    //this script moves the player according to his viewing orientation  >>> see FPLookAround for camera control!
    void MoveOnLookAxis()
{
    Vector3 forward = transform.forward * Input.GetAxis("Vertical");
    Vector3 sideways = transform.right * Input.GetAxis("Horizontal");

    Vector3 translation = (forward + sideways).normalized ;
        float speed = 0;

        if (translation.magnitude > 0)
        {
        
            if (jumpBehaviour.isJumping)
            {
                speed = walkingSpeed;
                isWalking = false;
                isRunning = false;
            }
            else if (Input.GetKey(KeyMap.runningKey))
            {
                speed = runningSpeed;
                isRunning = true;
                isWalking = false;

            }
            else
            {
                speed = walkingSpeed;
                isWalking = true;
                isRunning = false;
            }
        }
        else
        { 
            isWalking = false; 
            isRunning = false; 
        }

    Vector3 finalTranslation = translation * speed * Time.fixedDeltaTime;

    Vector3 finalPosition = rigidbody.position + finalTranslation;
      

    rigidbody.MovePosition(finalPosition);

    }

    
}
