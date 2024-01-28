using System;
using UnityEngine;

public class King : StateMachine, ITarget
{
    public static event Action OnDeath;
    public static King Instance;

    [SerializeField] KingAttackState _attack;
    [SerializeField] KingIdle _idle;

    [Space]
    [SerializeField] float _health = 300f;

    [Space]
    [SerializeField] Animator _animator;
    
    private bool _dead = false;

    private KingAttackTransition _attackTransition;

    public void Hit(float damage)
    {
        if (_dead)
            return;

        _health -= damage;

        if (_health > 0)
            return;

        _animator.SetTrigger("dead");
        _dead = true;
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        ChangeState(_idle);

        _attackTransition = new KingAttackTransition();
        _attackTransition.ToState = _attack;

        AddAnyTransition(_attackTransition);
    }

    public void StartAttack()
    {
        _attackTransition.Should = true;
    }
}
