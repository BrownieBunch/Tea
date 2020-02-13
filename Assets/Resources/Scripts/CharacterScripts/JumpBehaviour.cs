using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Jump and Float try with forces.
public class JumpBehaviour : CharacterController
{
    //check for 
    public bool isTouchingGround;
    KeyCode jumpKey = KeyCode.Space;
    public float jumpForce;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(jumpKey))
        {
            Debug.Log("Input for Jump.");
            if (isTouchingGround)
            {
                JumpAction();
            }
        }
        
    }

    void JumpAction()
    {
        rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    void GroundCheck()
    {
    }

}
