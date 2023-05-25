using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Enemies.Pools
{
    public class EnemiesObjectPool : AObjectsPool
    {
        [SerializeField] private GameObject enemyPrefab;
        private int poolSize = 20;
        private List<GameObject> objectPool = new List<GameObject>();

        private void Awake()
        {
            CreateObjectPool(objectPool,poolSize,enemyPrefab);
        }

        public override GameObject CallGetObjectFromPool()
        {
            return GetObjectFromPool(objectPool, enemyPrefab);
        }
    }
}