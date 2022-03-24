using UnityEngine;

namespace Infrastructure.Services.UserInput
{
    public interface IInputService
    {
        Vector2 GetAxis();
        bool IsAttackButtonUp();
    }
}