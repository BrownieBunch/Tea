using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DebugHelp();
    }

    void OnGUI()
    {
        Camera cam = Camera.main;
        Vector3 point = new Vector3();
        Event currentEvent = Event.current;
        Vector2 mousePos = new Vector2();

        // Get the mouse position from Event.
        // Note that the y position from Event is inverted.
        mousePos.x = currentEvent.mousePosition.x;
        mousePos.y = cam.pixelHeight - currentEvent.mousePosition.y;

        point = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, cam.nearClipPlane));

        //this yields nothing
        //point = cam.ScreenToWorldPoint(Input.mousePosition);

        GUILayout.BeginArea(new Rect(20, 20, 250, 120));
        GUILayout.Label("Screen pixels: " + cam.pixelWidth + ":" + cam.pixelHeight);
        GUILayout.Label("Mouse position: " + mousePos);
        GUILayout.Label("World position: " + point.ToString("F3"));
        GUILayout.EndArea();
    }


    public void DebugMouseRoutine()
    {
        StartCoroutine(DebugMouse(2));
        IEnumerator DebugMouse(int waitDuration)
        {
            print("Mouse Position: " + Input.mousePosition);
            print("ScreenToViewport Position: " + Camera.main.ScreenToViewportPoint(Input.mousePosition));
            print("ScreenToWorld Position: " + Camera.main.ScreenToWorldPoint(Input.mousePosition));
            print("Mouse Delta: " + Input.mouseScrollDelta);
            yield return new WaitForSeconds(waitDuration);
        }
    }


    void PrintMessageRoutine(string message)
    {
        float timeStamp = Time.time;
        float periodInSeconds = 1;
        if (Time.time > timeStamp + periodInSeconds)
        {
            timeStamp = Time.time;
            print(message);
        }
    }

    void DebugHelp()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Mouse Position: " + Input.mousePosition);
            Debug.Log("Mouse Input X: " + Input.GetAxis("Mouse X"));
            Debug.Log("Mouse Input Y: " + Input.GetAxis("Mouse Y"));
        }
    }

}
