public interface IState
{
    public void OnEnter();
    public void OnTick(float deltaTime);
    public void OnExit();
}
