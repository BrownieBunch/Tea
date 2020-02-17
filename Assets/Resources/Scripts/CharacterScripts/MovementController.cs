using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider), typeof(Rigidbody))]
public class MovementController : MonoBehaviour
{
    public bool canMove;
    public bool canJump;
    public bool canLevitate;
    public bool canFlapFly;

    public bool isWalking;
    public bool isRunning;
    public bool isJumping;
    public bool isLevitating;
    public bool isFlyFlapping;



    public virtual void Awake()
    {

    }
    // Use this for initialization
    void Start()
    {
        EnableMove();
       // canMove = true;
        canJump = true;
        canLevitate = true;
        canFlapFly = true;
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
