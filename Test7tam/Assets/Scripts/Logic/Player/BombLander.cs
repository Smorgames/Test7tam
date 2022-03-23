using UnityEngine;
using UnityEngine.UI;

namespace Logic.Player
{
    public class BombLander : MonoBehaviour
    {
        private const float ReloadTime = 3f;
    
        [SerializeField] private GameObject _bomb;
        [SerializeField] private Slider _slider;

        private float _counter;
        private bool _reloaded = true;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && _reloaded)
                LandBomb();

            ReloadProcess();
        }

        private void LandBomb()
        {
            Instantiate(_bomb, transform.position, Quaternion.identity);
            StartReload();
        }

        private void StartReload()
        {
            _counter = 0f;
            _slider.value = 1 - _counter / ReloadTime;
            _reloaded = false;
        }

        private void ReloadProcess()
        {
            if (_reloaded)
                return;

            _counter += Time.deltaTime;

            var normalizedValue = 1 - _counter / ReloadTime;
            _slider.value = normalizedValue;

            if (_counter >= ReloadTime) 
                _reloaded = true;
        }
    }
}