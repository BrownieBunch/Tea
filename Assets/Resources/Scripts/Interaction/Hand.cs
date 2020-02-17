using System.Collections;
using System.Collections.Generic;
using Resources.Scripts.Interaction;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public int ReachRange = 50;

    private float keyPressTimer = 0;
    private bool autoUpLock = false;
    private InteractiveItem itemInHand = null;

    private void Update()
    {
        //+++ Carrying updates +++
        if (itemInHand != null)
        {
            itemInHand.transform.position = this.transform.position; //Sets the item to the hand location
        }
        
        //+++ Key pressing Logic +++
        if (Input.GetKey(KeyMap.InteractKey))
        {
            keyPressTimer += Time.deltaTime;
        }
        bool longPressIsTriggerd = keyPressTimer % 60 > KeyMap.LongPressThresholdInSeconds; //Converts delta time to seconds for comparison

        if (!longPressIsTriggerd && !Input.GetKeyUp(KeyMap.InteractKey)) { return; }
        if (autoUpLock) //Lock the next key up event after a long press to stop double triggering
        {
            autoUpLock = false;
            return;
        }
        
        keyPressTimer = 0;
        autoUpLock = longPressIsTriggerd;

        //An interact has taken place, do a raycast to figure out wtf we are doing
        RaycastHit hit;
        Physics.Raycast( Camera.main.ScreenPointToRay( Input.mousePosition ), out hit, ReachRange );

        if (hit.collider == null ) { return; } //User is looking at the sky, they can fuck off the cheeky frog
        
        //+++ Item In hand Logic +++ This will try to drop an item, then return, no other interaction takes place
        if (itemInHand != null)
        {
            if (itemInHand.SetAsPutDown())
            {
                itemInHand = null;
                return;
            }
            Debug.Log("Failed to put down item, has the item pickup state been locked?");
        }
        
        //+++ Attempt to find an item to interact with +++
        if (hit.collider.tag != "InteractableItem") { return; }
        
        //No item was in the hand or put down is locked, continue with press logic
        var ii = hit.collider.GetComponent<InteractiveItem>();
        if (ii == null)
        {
            Debug.LogError("HAND: Tagged InteractiveItem does not have an II script set");
            return;
        }

        if (longPressIsTriggerd)
        { PickUpLogic(ii); }
        else
        { TouchLogic(ii); }
    }

    //Short press logic handles instant interaction
    private void TouchLogic( InteractiveItem ii )
    {
        var interaction = ii.GetInteractionWithBrainState( InteractionType.Touch );
        if (interaction == null)
        {
            Debug.Log("HAND: No interaction available for this BrainState");
            return;
        }
            
        interaction.RunAction();
    }

    //Long press logic handles picking items up
    private void PickUpLogic( InteractiveItem ii )
    {
        if (ii.SetAsPickedUp())
        {
            itemInHand = ii; 
        }
    }
}
