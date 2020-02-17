using System;
using System.Collections;
using System.Collections.Generic;
using Resources.Scripts.Interaction;
using Resources.Scripts.Interaction.Interactions;
using UnityEngine;

//Custom item code, expects to be on object with an interactive item script
public class TestInteraction : BaseInteraction
{
    public override void RunAction()
    {
        ii.IsEmitting = false;
        ii.Brain.State = BrainState.Angry;
        Debug.Log("Yes I ran");
    }
}
