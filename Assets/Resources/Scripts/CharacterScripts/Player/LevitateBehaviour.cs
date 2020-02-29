using UnityEngine;
using System.Collections;

public class LevitateBehaviour : MonoBehaviour
{
    public float levitatingSpeed = 3;

    MovementController movementController;

    private void Awake()
    {
        movementController = GetComponent<MovementController>();
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (movementController.canLevitate)
        {
            EnableLevitate();

            if (movementController.isLevitating)
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
                Vector3 finalPosition = GetComponent<Rigidbody>().position + finalTranslation;
                GetComponent<Rigidbody>().MovePosition(finalPosition);
        }
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
        if (GetComponent<Rigidbody>().useGravity)
        {
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            movementController.isLevitating = true;
        }
        else
        {
            GetComponent<Rigidbody>().useGravity = true;
            movementController.isLevitating = false;
        }
    }




}
