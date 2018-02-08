using UnityEngine;

namespace DefaultNamespace
{
    public class GameManager : MonoBehaviour
    {
        private static bool _isPause;
        private static int _currentHealth;

        public static GameManager Instance { get; private set; } 

        
        
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


        public static void TakeDamage(int damege)
        {
            if (_currentHealth == 0)
            {
                _isPause = true;
                return;
            }

            _currentHealth -= damege;
        }

        public static bool PauseGame()
        {
            return !_isPause;
        }

        private void Update()
        {
            if (_isPause)
            {
                Time.timeScale = 0;
                Debug.Log("GameOver");
            }

        }
    }
}