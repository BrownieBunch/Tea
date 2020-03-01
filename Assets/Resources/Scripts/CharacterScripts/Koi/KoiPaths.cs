using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class KoiPaths : MonoBehaviour
{
    float upperLimit = 2f;
    float lowerLimit = -2f;
   
    Transform[] points;
    

    private void Awake()
    {
        //includes parent
        // points = GetComponentsInChildren<Transform>();
        //only children
        points = transform.Cast<Transform>().ToArray();
        //or
        /*
        Vector3[] waypoints = new Vector3[pathHolder.childCount];
		for (int i = 0; i < waypoints.Length; i++) {
			waypoints [i] = pathHolder.GetChild (i).position;
			waypoints [i] = new Vector3 (waypoints [i].x, transform.position.y, waypoints [i].z);
		}
        */
    }

    // Start is called before the first frame update

    void Start()
    {
        foreach (Transform point in points)
        {
            point.transform.position = new Vector3(point.transform.position.x, point.transform.position.y + Random.Range(lowerLimit, upperLimit), point.transform.position.z);
            point.gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }



}
