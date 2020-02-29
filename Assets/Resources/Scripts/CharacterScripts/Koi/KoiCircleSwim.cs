using UnityEngine;
using System.Collections;

public class KoiCircleSwim : MonoBehaviour
{
    public Transform pivotPoint;

    public float radius;
    public float durationFor1CircleInSeconds = 3;

    // Use this for initialization
    void Start()
    {
               transform.position = new Vector3(pivotPoint.position.x + radius, pivotPoint.position.y, pivotPoint.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(pivotPoint.position, Vector3.up, -360 / durationFor1CircleInSeconds * Time.deltaTime);
    }
}
