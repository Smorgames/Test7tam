using UnityEngine;

namespace Logic.Enemy
{
    public class EnemyAnimator : MonoBehaviour
    {
        private static readonly int Dead = Animator.StringToHash("Dead");
        
        [SerializeField] private Animator _animator;

        public void TriggerDead() => 
            _animator.SetTrigger(Dead);
    }
}