public interface ITransition
{
    public IState ToState { get; set; }
    public bool ShouldTransition(StateMachine stateMachine);
}
