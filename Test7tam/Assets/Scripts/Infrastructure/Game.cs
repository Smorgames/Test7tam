using System.Collections;
using Infrastructure.Services.UserInput;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure
{
    public class Game : MonoBehaviour
    {
        private readonly WaitForSeconds WaitBeforeRestart = new WaitForSeconds(1f);
        
        [SerializeField] private GameObject _mobileHUD;

        private InputService _inputService;
        private GameReloader _gameReloader;

        private void Awake()
        {
            if (CurrentPlatformWindows())
            {
                _mobileHUD.SetActive(false);
                _inputService = new StandaloneInputService();
            }
            else
                _inputService = new MobileInputService();

            _gameReloader = new GameReloader(this);
        }

        public InputService GetInputService() => _inputService;

        public void SetEnemyAmount(int amount) => 
            _gameReloader.SetEnemyAmount(amount);
        
        public void EnemyDead() => 
            _gameReloader.EnemyDead();

        public void Restart() => 
            StartCoroutine(RestartCoroutine());

        private static bool CurrentPlatformWindows()
        {
            Debug.Log(Application.platform);
            return Application.platform == RuntimePlatform.WindowsEditor ||
                   Application.platform == RuntimePlatform.WindowsPlayer;
        }

        private IEnumerator RestartCoroutine()
        {
            yield return WaitBeforeRestart;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}