using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script controls movement of player in first person/3D mode.

// Smooth transitions with GetAxis Raw and then Lerping? 


public class FPMovement : MonoBehaviour
{
    public float walkingSpeed = 5;
    public float runningSpeed = 10;

    Rigidbody rigidbody;
    MovementController movementController;

    public void Awake()
    {
        movementController = GetComponent<MovementController>();
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if ((movementController.canMove) && (!movementController.isLevitating))
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

            if ((movementController.isJumping) | (movementController.isFlyFlapping))
            {
                speed = walkingSpeed;
                movementController.isWalking = false;
                movementController.isRunning = false;
            }
            else if (Input.GetKey(KeyMap.runningKey))
            {
                speed = runningSpeed;
                movementController.isRunning = true;
                movementController.isWalking = false;

            }
            else
            {
                speed = walkingSpeed;
                movementController.isWalking = true;
                movementController.isRunning = false;
            }
        }
        else
        {
            movementController.isWalking = false;
            movementController.isRunning = false; 
        }

    Vector3 finalTranslation = translation * speed * Time.fixedDeltaTime;
    Vector3 finalPosition = rigidbody.position + finalTranslation;
    rigidbody.MovePosition(finalPosition);
    }

    
}
