using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogBehaviourScript : MonoBehaviour
{
    Animation animation;
    public float jumpingPeriod = 3;
    
    private void Awake()
    {
        animation = GetComponent<Animation>();

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (TimeWatchUtility.timeCheck(jumpingPeriod))
        {
            Debug.Log("Frog says : 'Jump Time!'");
              animation.Play("Jump");
        }

    }
}
