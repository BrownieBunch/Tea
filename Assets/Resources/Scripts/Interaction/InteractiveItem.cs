using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Custom item code, expects to be on object with an interactive item script
public interface IInteractiveItem
{
    
}

//Main script to be attached to objects that need to be intractable
public class InteractiveItem : MonoBehaviour
{
    public bool isEnabled = true;
    public bool isEmitting = false;
    public bool CanBePickedUp = false;
    
    //Emissions
    public ParticleSystem particleEmission;

    public void Start()
    {
        StartEmissions();
    }

    public void Update()
    {
        UpdateEmissions();
    }

    private void StartEmissions()
    {
        var emo = Instantiate(particleEmission, transform.position, particleEmission.transform.rotation);
        emo.transform.SetParent(this.transform);
        particleEmission = emo;
    }

    private void UpdateEmissions()
    {
        if (isEmitting && !particleEmission.isEmitting)
        {
            particleEmission.Play();
        }
        else if (!isEmitting && particleEmission.isEmitting)
        {
            particleEmission.Stop();
        }
    }
}
