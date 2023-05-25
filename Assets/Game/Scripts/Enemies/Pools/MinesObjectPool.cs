using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Enemies.Pools
{
    public class MinesObjectPool : AObjectsPool
    {
        [SerializeField] private GameObject minePrefab;
        private int poolSize = 20;
        private List<GameObject> objectPool = new List<GameObject>();

        private void Awake()
        {
            CreateObjectPool(objectPool,poolSize, minePrefab);
        }

        public override GameObject CallGetObjectFromPool()
        {
            return GetObjectFromPool(objectPool, minePrefab);
        }
    }
}