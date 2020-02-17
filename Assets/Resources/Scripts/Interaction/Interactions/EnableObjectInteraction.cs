using UnityEngine;

namespace Resources.Scripts.Interaction.Interactions
{
    public class EnableObjectInteraction : BaseInteraction
    {
        public GameObject ObjectToEnable;
        
        public override void RunAction()
        {
            ObjectToEnable.SetActive(true);
        }
    }
}