using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class TimeWatchUtility : MonoBehaviour
{

    static float timeStamp;

    private void Start()
    {
               timeStamp = Time.time;
        // Debug.Log("Timestamp " + timeStamp);
    }

    private void Update()
    {
        
    }
        public static bool timeCheck(float period)
        {
            if (Time.time > timeStamp + period)
            {
                Debug.Log("Tick. @ " + Time.time);
                timeStamp = Time.time;
                return true;
            }
            else
                return false;
        }

}
