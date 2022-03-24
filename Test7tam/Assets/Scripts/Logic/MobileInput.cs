using Logic.JoystickLogic;
using UnityEngine;
using UnityEngine.UI;

namespace Logic
{
    public class MobileInput : MonoBehaviour
    {
        private const string JoystickTag = "Joystick";
        private const string AttackButtonTag = "AttackButton";

        private static Joystick _joystick;
        private static Button _attackButton;

        private void Awake() =>
            FindUIElements();

        public static Vector2 GetAxis() => new Vector2(_joystick.Horizontal, _joystick.Vertical);

        public static bool IsAttackButtonUp() => _attackButton.IsInvoking();

        private void FindUIElements()
        {
            var joystickObject = GameObject.FindWithTag(JoystickTag);
            if (joystickObject != null)
                _joystick = joystickObject.GetComponent<FloatingJoystick>();

            var attackButtonObject = GameObject.FindWithTag(AttackButtonTag);
            if (attackButtonObject != null)
                _attackButton = attackButtonObject.GetComponent<Button>();
        }
    }
}