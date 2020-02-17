using UnityEngine;
using System.Collections;

public class FlyFlapBehaviour : MonoBehaviour
{
    public float jumpingForce = 3;

    MovementController movementController;
    Rigidbody rigidbody;

    private void Awake()
    {
        movementController = GetComponent<MovementController>();
        rigidbody = GetComponent<Rigidbody>();
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (movementController.canFlapFly)
        { 
        if (Input.GetKeyDown(KeyMap.flyflappingKey))
        {
                movementController.isFlyFlapping = true;
                rigidbody.AddForce(Vector3.up * jumpingForce, ForceMode.Impulse);
         }
        else
            {
                movementController.isFlyFlapping = false;
            }
        }
    }
}
