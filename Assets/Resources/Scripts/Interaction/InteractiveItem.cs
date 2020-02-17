using System;
using System.Collections;
using System.Collections.Generic;
using Resources.Scripts.Interaction;
using Resources.Scripts.Interaction.Interactions;
using UnityEngine;

//Main script to be attached to objects that need to be intractable
public class InteractiveItem : MonoBehaviour
{
    public Brain Brain { get; private set; }

    //Emissions
    public bool IsEmitting = false;
    public ParticleSystem particleEmission;
    private bool areEmissionsSetUp = false;
    
    //Pick up settings
    public bool CanBePickedUp = false;
    public bool IsPickedUp { get; private set; }
    public Vector3 PickedUpScale = new Vector3(0.5f,0.5f,0.5f); //What is the item resized to on pickup
    private Vector3 startingScale; //Save slot for item resizing

    public List<IInteraction> Interactions = new List<IInteraction>();

    public void Start()
    {
        IsPickedUp = false;
        
        Brain = GameObject.FindGameObjectWithTag("Brain")?.GetComponent<Brain>();
        if( Brain == null ) { Debug.Log("COULD NOT FINE BROWNIE BRAIN HELLLPPPPP"); return; }
        
        //Particle system logic for emissions
        StartEmissions();
    }

    public void Update()
    {
        UpdateEmissions();
    }

    public bool SetAsPickedUp()
    {
        if (!CanBePickedUp) { return false; }
        if (IsPickedUp) { Debug.Log("Attempted to pick up an item that is already picked up" ); return false; }

        startingScale = transform.localScale;
        transform.localScale = PickedUpScale;
        IsPickedUp = true;
        
        return true;
    }

    public bool SetAsPutDown()
    {
        if (!CanBePickedUp) { return false; } //Force users to keep holding item? May be useful sometime
        if (!IsPickedUp) { Debug.Log("Attempted to put down non picked up item" ); return false; }

        transform.localScale = startingScale;
        IsPickedUp = false;
        
        return true;
    }

    private void StartEmissions()
    {
        if (particleEmission == null) { return;}
        var emo = Instantiate(particleEmission, transform.position, particleEmission.transform.rotation);
        emo.transform.SetParent(this.transform);
        particleEmission = emo;
        areEmissionsSetUp = true;
    }

    private void UpdateEmissions()
    {
        if (!areEmissionsSetUp) { return; }
        if (IsEmitting && !particleEmission.isEmitting)
        {
            particleEmission.Play();
        }
        else if (!IsEmitting && particleEmission.isEmitting)
        {
            particleEmission.Stop();
        }
    }

    public IInteraction GetInteractionWithBrainState( InteractionType type )
    {
        if (IsPickedUp) { return null;} //Picked up items do not interact, they must be dropped
        
        foreach (var action in Interactions)
        {
            if (action.Type == type &&
                action.AffectedBrainState == Brain.State)
            {
                return action;
            }
        }

        return null;
    }
}
