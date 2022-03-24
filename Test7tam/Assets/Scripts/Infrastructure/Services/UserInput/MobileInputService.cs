using Logic;
using UnityEngine;

namespace Infrastructure.Services.UserInput
{
    public class MobileInputService : InputService
    {
        public override Vector2 GetAxis() => MobileInput.GetAxis();

        public override bool IsAttackButtonUp() => MobileInput.IsAttackButtonUp();
    }
}