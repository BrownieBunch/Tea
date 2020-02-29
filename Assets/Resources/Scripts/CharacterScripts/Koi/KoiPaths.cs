using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class KoiPaths : MonoBehaviour
{
    float upperLimit = 4f;
    float lowerLimit = -4f;
   
    Transform[] points;
    

    private void Awake()
    {
        //includes parent
        // points = GetComponentsInChildren<Transform>();
        //only children
        points = transform.Cast<Transform>().ToArray();
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
