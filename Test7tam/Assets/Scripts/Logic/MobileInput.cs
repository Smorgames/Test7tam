using System.Collections;
using System.Collections.Generic;
using Logic.JoystickLogic;
using UnityEngine;
using UnityEngine.UI;

namespace Logic
{
    public class MobileInput : MonoBehaviour
    {
        private const string JoystickTag = "Joystick";

        private static Joystick _joystick;
        private static bool _isAttackButtonPressed;

        private void Awake() => 
            FindUIElements();

        public static Vector2 GetAxis() => new Vector2(_joystick.Horizontal, _joystick.Vertical);

        public static bool IsAttackButtonUp() => _isAttackButtonPressed;

        public void SetActiveAttackButton() => 
            StartCoroutine(SetActiveAttackButtonCoroutine());

        private IEnumerator SetActiveAttackButtonCoroutine()
        {
            _isAttackButtonPressed = true;
            yield return new WaitForSeconds(Time.deltaTime);
            _isAttackButtonPressed = false;
        }

        private void FindUIElements()
        {
            var joystickObject = GameObject.FindWithTag(JoystickTag);
            if (joystickObject != null)
                _joystick = joystickObject.GetComponent<FloatingJoystick>();
        }
    }
}