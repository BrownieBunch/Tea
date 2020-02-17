using Resources.Scripts.Interaction;
using UnityEngine;

public class InteractionTrigger : MonoBehaviour
{
    public InteractionType TriggerType;
    public bool TargetSelf = false; //Set to true to make Trigger target its own II script

    private void OnTriggerStay(Collider other)
    {
        if (other.tag != "InteractableItem") { return; } //A non ii item has entered the trigger, we dont deal with those here

        InteractiveItem ii;
        
        if (TargetSelf)
        {
            ii = this.GetComponent<InteractiveItem>();
        }
        else
        {
            ii = other.GetComponent<InteractiveItem>();
        }

        if (ii == null)
        {
            Debug.LogError("TRIGGER: II script not set on target");
            return;
        }
        
        var interaction = ii.GetInteractionWithBrainState( TriggerType );
        if (interaction == null)
        {
            Debug.Log("TRIGGER: No interaction available for this BrainState");
            return;
        }
            
        interaction.RunAction();
    }
}
