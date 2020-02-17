using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider), typeof(Rigidbody))]
public class CharacterControllerLocalVS : MonoBehaviour
{
    public static bool canMove;
    [SerializeField]
    protected static float walkingSpeed;
    [SerializeField]
    protected static float runningSpeed;
    [SerializeField]
    protected static float levitatingSpeed;
    [SerializeField]
    protected static float jumpingForce;


    [HideInInspector]
    public Rigidbody rigidbody;
    [HideInInspector]
    public Collider collider;

    public virtual void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();

        walkingSpeed = 5;
        runningSpeed = 10;
        levitatingSpeed = 3;
        jumpingForce = 7;
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
