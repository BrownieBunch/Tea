using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Custom item code, expects to be on object with an interactive item script
public class TestItem : MonoBehaviour, IInteractiveItem
{
    private InteractiveItem ii;

    public void Start()
    {
        ii = GetComponent<InteractiveItem>();
    }
}
