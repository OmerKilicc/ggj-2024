using UnityEngine;

namespace AI
{
    public class OnPlayerEnterSphere : MonoBehaviour, ITransition
    {
        [SerializeField] private float _detectionRange = 10f;

        private float _detectionRangeSquared;
        private Transform _playerTransform;

        public IState ToState { get; set; }

        private void Start()
        {
            _playerTransform = FindPlayerTransform();
            _detectionRangeSquared = _detectionRange * _detectionRange;
        }

        public bool ShouldTransition(StateMachine stateMachine)
        {
            if (_playerTransform == null)
            {
                _playerTransform = FindPlayerTransform();
                return false;
            }

            float distSq = (_playerTransform.position - transform.position).sqrMagnitude;

            return _detectionRangeSquared > distSq;
        }

        private Transform FindPlayerTransform() => GameObject.FindGameObjectWithTag("Player")?.transform ?? null;


#if UNITY_EDITOR

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _detectionRange);
        }

#endif
    }
}
