using UnityEngine;

public class KingAttackState : MonoBehaviour, IState
{
    Player player;

    [SerializeField] BaseRangedJoke _base;
    [SerializeField] KingTripleShoot _special;

    [SerializeField] private float _basicInterval = .5f;
    [SerializeField] private int _basicBeforeSpecial;

    [Space]
    [SerializeField] private float _health = 300f;

    public void OnEnter()
    {
        player = Player.Instance;
    }

    public void OnExit()
    {

    }

    public void OnTick(float deltaTime)
    {
        if (player == null)
            return;

        if (ShouldSpecial())
        {
            _basicThrown = 0;
            ThrowSpecial();
            return;
        }

        if (ShouldBasic(deltaTime))
        {
            _basicWait = 0f;
            ThrowBasic();
        }
    }

    float _basicWait = 0f;
    private bool ShouldBasic(float dt)
    {
        _basicWait += dt;
        return _basicWait > _basicInterval;
    }

    private int _basicThrown;
    private bool ShouldSpecial()
    {
        return _basicThrown >= _basicBeforeSpecial;
    }

    private void ThrowBasic()
    {
        _basicThrown++;

        _base.transform.forward = (player.transform.position - _base.transform.position).normalized;

        _base.Make();
    }

    private void ThrowSpecial()
    {
        _special.Make();
    }
}
