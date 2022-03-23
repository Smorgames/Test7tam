using UnityEngine;

namespace Logic.Player
{
    public class PlayerAnimator : MonoBehaviour
    {
        private static readonly int Dead = Animator.StringToHash("Dead");
        private static readonly int Speed = Animator.StringToHash("Speed");

        [SerializeField] private Animator _animator;

        public void TriggerDead() => 
            _animator.SetTrigger(Dead);

        public void SetSpeed(float value) => 
            _animator.SetFloat(Speed, value);
    }
}