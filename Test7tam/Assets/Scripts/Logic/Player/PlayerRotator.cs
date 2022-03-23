using UnityEngine;

namespace Logic.Player
{
    public class PlayerRotator : MonoBehaviour
    {
        [SerializeField] private PlayerMovement _movement;
        [SerializeField] private Transform _graphic;

        private void Update() => 
            SetRotation();

        private void SetRotation()
        {
            var x = _movement.GetAxis().x;
            
            if (x == 0) 
                return;
            
            var angle = x > 0 ? 0 : 180;
            _graphic.transform.localRotation = Quaternion.Euler(0f, angle, 0f);
        }
    }
}
