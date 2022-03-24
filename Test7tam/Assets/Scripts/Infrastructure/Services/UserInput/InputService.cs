using UnityEngine;

namespace Infrastructure.Services.UserInput
{
    public abstract class InputService : IInputService
    {
        public abstract Vector2 GetAxis();
        public abstract bool IsAttackButtonUp();
    }
}