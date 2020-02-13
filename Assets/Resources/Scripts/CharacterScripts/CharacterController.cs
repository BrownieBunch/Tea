using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider), typeof(Rigidbody))]
public class CharacterController : MonoBehaviour
{
    public static bool canMove;
    public float walkingSpeed;
    public float runningSpeed;
    public float floatingSpeed;


    [HideInInspector]
    public Rigidbody rigidbody;
    public Collider collider;

    public virtual void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
    }
    // Use this for initialization
    void Start()
    {
        EnableMove();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EnableMove()
    {
        canMove = true;
    }

    public void DisableMove()
    {
        canMove = false;
    }
}
