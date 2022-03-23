using UnityEngine;

namespace Logic.Enemy
{
    public class EnemyRotator : MonoBehaviour
    {
        [SerializeField] private Transform _graphic;
        
        public void SetRotationBasedOn(Vector2 moveDirection)
        {
            var x = moveDirection.x;
            
            if (x == 0) 
                return;
            
            var angle = x > 0 ? 0 : 180;
            _graphic.transform.localRotation = Quaternion.Euler(0f, angle, 0f);
        }
    }
}