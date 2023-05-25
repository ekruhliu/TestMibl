using System;
using Game.Scripts.Player;
using UnityEngine;
using UnityEngine.AI;

namespace Game.Scripts.Core
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
        
        public event Action OnGameOverAction;
        public event Action<string> OnSetGameTimeAction;
        
        public PlayerController Player
        {
            get { return _player; }
        }

        public Bounds SpawnBounds
        {
            get { return _spawnSurface.sourceBounds; }
        }

        [SerializeField] private PlayerController _player;
        [SerializeField] private NavMeshData _spawnSurface;
        private float startTime;

        private void Awake()
        {
            if (!Instance)
                Instance = this;
            else
                Destroy(gameObject);
        }

        private void Start()
        {
            startTime = Time.time;
        }

        private void OnEnable()
        {
            _player.OnPlayerDieAction += GameOver;
        }

        private void OnDisable()
        {
            _player.OnPlayerDieAction -= GameOver;
        }

        private void GameOver()
        {
            float elapsedTime = Time.time - startTime;
            float minutes = Mathf.FloorToInt(elapsedTime / 60);
            float seconds = elapsedTime % 60;
            
            OnGameOverAction?.Invoke();
            OnSetGameTimeAction?.Invoke(string.Format("{0:00}:{1:00}", minutes, seconds));
        }
    }
}