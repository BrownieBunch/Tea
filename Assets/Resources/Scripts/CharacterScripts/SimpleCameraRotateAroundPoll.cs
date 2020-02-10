using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCameraRotateAroundPoll : MonoBehaviour
{
    //input means
    //Will have a mousewheel for zoom in / zoom out
    public float zoomSensitivity;
    public Vector2 zoomBounds;
    public Vector2 heightRange;

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
        CameraRotateAroundTarget();
        CameraHeightChangeAimed();
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


    void CameraRotateAroundTarget()
    {
        parent.transform.Rotate(new Vector3(0, Input.GetAxis("Horizontal"), 0) * turnSensitivity, Space.World);
    }

    void CameraHeightChangeAimed()
    {
        Vector3 height = new Vector3(0, Input.GetAxis("Vertical"), 0) * pitchSensitivity;
        float yvalue = transform.position.y;
        float newYvalue = transform.position.y + height.y;

        if ((newYvalue > heightRange.x) && (newYvalue < heightRange.y) )
        {
            transform.position += height;
            transform.LookAt(this.transform.parent);
        }
    }

    void CameraAim()
    {
        if (Input.GetAxis("Vertical") > 0)
        {
            Vector3 height = new Vector3(0, Input.GetAxis("Vertical"), 0) * pitchSensitivity;
            float heightAB = height.magnitude;
            float xvalue = transform.localPosition.x;
            float zvalue = transform.localPosition.z;
            float hypothenuse = Mathf.Sqrt(Mathf.Pow(xvalue, 2) + Mathf.Pow(zvalue, 2));
            Debug.Log("Camera X " + xvalue);
            Debug.Log("Camera Z " + zvalue);
            Debug.Log("Distance from root" + hypothenuse);
            Debug.Log("Camera moved upwards a height of " + heightAB);
            float angleRad = Mathf.Atan2(heightAB, hypothenuse);
            float angleDeg = angleRad * Mathf.Rad2Deg;
            Debug.Log("Angle is " + angleDeg);
        }
    }
}