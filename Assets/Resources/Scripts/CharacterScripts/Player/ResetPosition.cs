using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPosition : MonoBehaviour
{
    public Transform resetPosition;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = resetPosition.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            transform.position = resetPosition.position;
        }
    }
}
