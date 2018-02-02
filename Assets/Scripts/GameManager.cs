using UnityEngine;

namespace DefaultNamespace
{
    public class GameManager : MonoBehaviour
    {
        public enum CurrentGameState
        {
            Start,
            pause,
            GameOver
        }

        private static bool _isPause;
        private static int _currentHealth;

        public static GameManager Instance;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            Init();
        }

        private static void Init()
        {
            _isPause = false;
            _currentHealth = 10;
        }


        public static void TakeDamage(int Damege)
        {
            if (_currentHealth == 0)
            {
                _isPause = true;
                return;
            }

            _currentHealth -= Damege;
        }

        public static bool PauseGame()
        {
            return !_isPause;
        }

        private void Update()
        {
            if (_isPause)
                Time.timeScale = 0;
        }
    }
}