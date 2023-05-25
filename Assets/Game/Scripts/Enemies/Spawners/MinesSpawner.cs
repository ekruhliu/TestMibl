using System.Collections;
using Game.Scripts.Core;
using Game.Scripts.Data;
using Game.Scripts.Enemies.Pools;
using UnityEngine;

namespace Game.Scripts.Enemies.Spawners
{
    public class MinesSpawner : ASpawner
    {
        [SerializeField] private EnemyData _enemyData;
        [SerializeField] private MinesObjectPool _minesObjectPool;
        private Coroutine _spawnRoutine;
        
        private void Start()
        {
            _spawnRoutine = StartCoroutine(SpawnObjectsCoroutine());
        }
        
        private void OnEnable()
        {
            GameManager.Instance.OnGameOverAction += StopCoroutineOnGameOver;
        }

        private void OnDisable()
        {
            GameManager.Instance.OnGameOverAction -= StopCoroutineOnGameOver;
        }

        protected override IEnumerator SpawnObjectsCoroutine()
        {
            while (true)
            {
                GameObject obj = _minesObjectPool.CallGetObjectFromPool();
                if (obj != null)
                {
                    Vector3 spawnPosition = GetRandomPositionOnSurface(GameManager.Instance.SpawnBounds);
                    obj.transform.position = spawnPosition;
                    obj.SetActive(true);
                }
                yield return new WaitForSeconds(Random.Range(_enemyData.MineSpawnCooldownRange.x, _enemyData.MineSpawnCooldownRange.y));
            }
        }

        protected override void StopCoroutineOnGameOver()
        {
            if(_spawnRoutine != null)
                StopCoroutine(_spawnRoutine);
        }
    }
}