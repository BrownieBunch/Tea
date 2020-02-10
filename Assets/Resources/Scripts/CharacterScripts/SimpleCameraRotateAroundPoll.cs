using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCameraRotateAroundPoll : MonoBehaviour
{
    //input means
    //Will have a mousewheel for zoom in / zoom out
    public float zoomSensitivity;
    public Vector2 zoomBounds;

    //Will have keyboard to move camera left right and up and down 
    public float turnSensitivity;
    public float pitchSensitivity;

    Camera camera;
    GameObject parent;

    private void Awake()
    {
        parent = transform.parent.gameObject;
        camera = GetComponent<Camera>();

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CameraZoom();
        CameraTurnAroundAxis();
       // CameraMoveUpDown();
    }

    private void LateUpdate()
    {
        
    }

    void CameraZoom()
    {
        camera.fieldOfView += Input.mouseScrollDelta.y * zoomSensitivity;

        //define limit to FoV
        if (camera.fieldOfView > zoomBounds.y)
        { camera.fieldOfView = zoomBounds.y; }
        if (camera.fieldOfView < zoomBounds.x)
        { camera.fieldOfView = zoomBounds.x; }
    }


    void CameraTurnAroundAxis()
    {
        parent.transform.Rotate(new Vector3(0, Input.GetAxis("Horizontal"), 0) * turnSensitivity, Space.World);
    }

    void CameraMoveUpDown()
    {
        if (Input.GetAxis("Vertical") > 0)
        { 
        Vector3 height = new Vector3(0, Input.GetAxis("Vertical"), 0) * pitchSensitivity;
        transform.position += height;

        float heightAB = height.magnitude;
        float xvalue = transform.localPosition.x;
        float zvalue = transform.localPosition.z;
        float hypothenuse = Mathf.Sqrt(Mathf.Pow(xvalue, 2) + Mathf.Pow(zvalue, 2));
        // aim at thingie: distance of root from XZ position of target = hypotenuse
        // side = input * turn, Y distance
        // cot = height / hypothenuse > angle = 
        float angleRad = Mathf.Acos(heightAB / hypothenuse);
        float angleDeg = angleRad * Mathf.Rad2Deg;
        Vector3 angleTurn = new Vector3(angleDeg, 0, 0);
            // if (angleDeg > 0)
            //   transform.Rotate(angleTurn, Space.Self);
            /*
            if (rotationAroundXaxis < 180 && rotationAroundXaxis > 0)
            {
                rotationAroundXaxis = Mathf.Clamp(rotationAroundXaxis, 0, 90);
            }
            else if (rotationAroundXaxis < 360 && rotationAroundXaxis > 180)
            {
                rotationAroundXaxis = Mathf.Clamp(rotationAroundXaxis, 270, 360);
            }

            cameraRotationEuler = new Vector3(rotationAroundXaxis, 0, 0);
            */ 

        }
    }
}
