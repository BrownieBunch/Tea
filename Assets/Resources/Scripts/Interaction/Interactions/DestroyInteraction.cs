namespace Resources.Scripts.Interaction.Interactions
{
    public class DestroyInteraction : BaseInteraction
    {
        public override void RunAction()
        {
            Destroy( gameObject );
        }
    }
}