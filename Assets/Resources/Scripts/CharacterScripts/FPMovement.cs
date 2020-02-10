using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script controls movement of player in first person/3D mode.
[RequireComponent(typeof(Collider), typeof(Rigidbody))]
public class FPMovement : Player
{

    public override void Awake()
    {
        base.Awake();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (canMove)
        { MoveOnLookAxis(); }
    }

    //this script moves the player according to his viewing orientation  >>> see FPLookAround for camera control!
    void MoveOnLookAxis()
{
    Vector3 forward = transform.forward * Input.GetAxis("Vertical");
    Vector3 sideways = transform.right * Input.GetAxis("Horizontal");

    Vector3 translation = (forward + sideways) * speed * Time.fixedDeltaTime;

    Vector3 finalPosition = GetComponent<Rigidbody>().position + translation;
    GetComponent<Rigidbody>().MovePosition(finalPosition);
    }
}
