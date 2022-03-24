using UnityEngine;

namespace Infrastructure.Services.UserInput
{
    public class StandaloneInputService : InputService
    {
        private const string VerticalAxis = "Vertical";
        private const string HorizontalAxis = "Horizontal";
        
        public override Vector2 GetAxis() => 
            new Vector2(Input.GetAxisRaw(HorizontalAxis), Input.GetAxisRaw(VerticalAxis));

        public override bool IsAttackButtonUp() => 
            Input.GetKeyDown(KeyCode.Space);
    }
}