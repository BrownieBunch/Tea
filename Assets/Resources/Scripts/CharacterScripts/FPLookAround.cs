using UnityEngine;
using System.Collections;
using System;
using System.Windows;


//this script affects the camera in first person mode. 
//The camera is a child object to the player gameObject.
//It follows the mouse movement and has zooming options, within a predefined range.
//Movement of the mouse on the X axis (screen coordinate system) rotates the parent gameobject itself (and thus the camera too) around the Y axis  (world coordinate system), 
//while movement of the mouse on the Y axis (screen coordinate system) rotates the camera on the X axis (world coordinate system).
//Finally, the values are clamped so that the camera can't look behind the player.

//The script is inspired by the Brackeys tutorial ' FIRST PERSON MOVEMENT in Unity - FPS Controller '.
//https://www.youtube.com/watch?v=_QajrabyTJc


public class FPLookAround : CharacterController
{
    Camera followCamera;
    Transform playerTransform;

    [SerializeField]
    float mouseSensitivity;
    [SerializeField]
    float zoomSensitivity;
    [SerializeField]
    Vector2 zoomBounds;
    [SerializeField]
    float startingFoV;

    public Vector2 mouseStartingPosition;

    float playerRotationAroundY;
    float cameraRotationAroundX;
    Vector3 cameraRotationEuler;

    // Use this for initialization
    void Start()
    {
        mouseSensitivity = 300;
        zoomSensitivity = 5;
        zoomBounds = new Vector2(40, 80);
        startingFoV = 60;

        Cursor.lockState =  CursorLockMode.Locked;
        followCamera = GetComponentInChildren<Camera>();
        playerTransform = transform;
        followCamera.fieldOfView = startingFoV;
    }

    // Update is called once per frame
    void Update()
    {
        //receive input in update
        if (canMove)
        {
            //angles are calculated here:
            PlayerTurnPrep();
            CameraLookAroundPrep();
            //zoom is executing here:
            CameraZoom();
        }
    }


    private void LateUpdate()
    {
        //execute on LateUpdate
        if (canMove)
        { 
            //actual turn of player
            playerTransform.Rotate(Vector3.up * playerRotationAroundY, Space.Self);
            //actual turn of camera
            followCamera.transform.localRotation = Quaternion.Euler(cameraRotationEuler);
        }
    }


    void PlayerTurnPrep()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float rotationAroundYaxis = mouseX * Time.deltaTime * mouseSensitivity;
        playerRotationAroundY = rotationAroundYaxis;
    }

    void CameraLookAroundPrep()
    {
        float mouseY = Input.GetAxis("Mouse Y");
        float rotationAroundXaxis = mouseY * Time.deltaTime * mouseSensitivity;
        rotationAroundXaxis = -rotationAroundXaxis;
        rotationAroundXaxis += followCamera.transform.localEulerAngles.x;
        
        //Why is this not behaving properly????
        //        rotationAroundXaxis = Mathf.Clamp(rotationAroundXaxis, -90f, 90f);

        //this works instead!!!
        if (rotationAroundXaxis < 180 && rotationAroundXaxis > 0)
        {
            rotationAroundXaxis = Mathf.Clamp(rotationAroundXaxis, 0, 90);
        }
        else if (rotationAroundXaxis < 360 && rotationAroundXaxis  > 180)
        {
            rotationAroundXaxis = Mathf.Clamp(rotationAroundXaxis, 270, 360);
        }

        cameraRotationEuler = new Vector3(rotationAroundXaxis, 0, 0);
    }

    void CameraZoom()
    {
        followCamera.fieldOfView += Input.mouseScrollDelta.y * zoomSensitivity;

        //define limit to FoV
        if (followCamera.fieldOfView > zoomBounds.y)
        { followCamera.fieldOfView = zoomBounds.y; }
        if (followCamera.fieldOfView < zoomBounds.x)
        { followCamera.fieldOfView = zoomBounds.x; }
    }
}
