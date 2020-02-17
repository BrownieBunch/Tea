using UnityEngine;
using System.Collections;

public class LevitateBehaviour : CharacterControllerLocalVS
{
    public bool islevitating;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        EnableLevitate();

        if (islevitating)
        {
            Vector3 upwards = Vector3.zero;
            if (Input.GetKey(KeyMap.floatingKeyGoUp))
            {
                upwards = Vector3.up;
                Debug.Log("Levitating with a speed of " + levitatingSpeed + " upwards.");
            }
            else if (Input.GetKey(KeyMap.floatingKeyGoDown))
            {
                upwards = Vector3.down;
            }

                Vector3 forward = transform.forward * Input.GetAxis("Vertical");
                Vector3 sideways = transform.right * Input.GetAxis("Horizontal");

                Vector3 translation = (forward + sideways + upwards);
                Vector3 finalTranslation = translation.normalized * levitatingSpeed * Time.fixedDeltaTime;
                Vector3 finalPosition = rigidbody.position + finalTranslation;
                rigidbody.MovePosition(finalPosition);
        }

    }


    void EnableLevitate()
    {
        if (Input.GetKeyDown(KeyMap.floatingKey))
        {
            GravityToggle();
        }
    }


    void GravityToggle()
    {
        if (rigidbody.useGravity)
        {
            rigidbody.useGravity = false;
            rigidbody.velocity = Vector3.zero;
            rigidbody.angularVelocity = Vector3.zero;

            islevitating = true;
        }
        else
        {
            rigidbody.useGravity = true;
            islevitating = false;
        }
    }




}
