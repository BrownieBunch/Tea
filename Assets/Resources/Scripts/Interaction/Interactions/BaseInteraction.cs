using UnityEngine;

namespace Resources.Scripts.Interaction.Interactions
{
    public abstract class BaseInteraction : MonoBehaviour, IInteraction
    {
        protected InteractiveItem ii;
        
        [SerializeField]
        private InteractionType type;
        public InteractionType Type => type;

        [SerializeField]
        private BrainState affectedBrainState;
        public BrainState AffectedBrainState => affectedBrainState;

        public void Start()
        {
            ii = GetComponent<InteractiveItem>();
            if (ii == null)
            {
                Debug.LogError("II script not found for Interaction");
                return;
            }
            ii.Interactions.Add(this); //Register interaction with II
        }

        public abstract void RunAction();
    }
}