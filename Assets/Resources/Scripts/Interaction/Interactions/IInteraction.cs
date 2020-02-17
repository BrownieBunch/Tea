namespace Resources.Scripts.Interaction.Interactions
{
    public interface IInteraction
    {
        InteractionType Type { get; }
        BrainState AffectedBrainState { get; }
        void RunAction();
    }
}