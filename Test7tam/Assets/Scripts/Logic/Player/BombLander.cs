using UnityEngine;

namespace Logic.Player
{
    public class BombLander : MonoBehaviour
    {
        private const float ReloadTime = 3f;
    
        [SerializeField] private GameObject _bomb;

        private float _counter;
        private bool _reloaded;

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
            _reloaded = false;
        }

        private void ReloadProcess()
        {
            if (_reloaded)
                return;

            _counter += Time.deltaTime;

            if (_counter >= ReloadTime) 
                _reloaded = true;
        }
    }
}