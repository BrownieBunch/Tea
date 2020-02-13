using UnityEngine;
using System.Collections;

public class LevitateBehaviour : CharacterController
{
    public bool isfloating;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyMap.floatingKey))
        { 
            rigidbody.useGravity = false;
            rigidbody.transform.position += Vector3.up * floatingSpeed * Time.deltaTime;
            Debug.Log("Levitating with a speed of " + floatingSpeed + " upwards.");
            isfloating = true;
        }


    }


}
