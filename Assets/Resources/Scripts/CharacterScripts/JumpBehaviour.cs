using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Jump and Float try with forces.
public class JumpBehaviour : CharacterControllerLocalVS
{
    //check for 
    public bool isGrounded;
    //
    public bool isJumping;

    public Transform feet;
    LevitateBehaviour levitateBehaviour;

    // Start is called before the first frame update
    void Start()
    {
        levitateBehaviour = GetComponent<LevitateBehaviour>();

    }

    // Update is called once per frame
    void Update()
    {
        
        if (!levitateBehaviour.islevitating)
        { 
        GroundCheck();

        if (Input.GetKeyDown(KeyMap.jumpingKey))
        {
            Debug.Log("Input for Jump.");


            if (isGrounded)
            {
                JumpAction();
            }
        }
        }

    }

    void JumpAction()
    {
        //correct this!!!
        // rigidbody.transform.position += Vector3.up * Time.deltaTime * floatingSpeed;
        //
        rigidbody.AddForce(Vector3.up * jumpingForce, ForceMode.Impulse);
        Debug.Log("Jump!");
    }

    void GroundCheck()
    {
        //("Ground");
        int layerIndex1 = 8;
        //Items
        int layerIndex2 = 9;


        LayerMask layerMask1 = 1 << layerIndex1;
        LayerMask layerMask2 = 1 << layerIndex2;
        LayerMask layerMask = layerMask1 | layerMask2;
        //layerMask = ~(layerMask);

        Collider[] hitColliders = Physics.OverlapBox(feet.position, Vector3.one, Quaternion.identity, layerMask);
        if (hitColliders.Length != 0)
        { 
            Debug.Log("Touching something " + hitColliders[0].gameObject.name);
            isGrounded = true;
            isJumping = false;

        }
        else
        {
            isGrounded = false;
            isJumping = true;
            Debug.Log("MidAir");
        }

    }



}
