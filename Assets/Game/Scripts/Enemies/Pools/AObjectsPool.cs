using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Enemies.Pools
{
    public abstract class AObjectsPool : MonoBehaviour
    {
        public abstract GameObject CallGetObjectFromPool();
        protected void CreateObjectPool(List<GameObject> objectPool, int poolSize, GameObject objectPrefab)
        {
            for (int i = 0; i < poolSize; i++)
            {
                GameObject obj = Instantiate(objectPrefab);
                obj.SetActive(false);
                objectPool.Add(obj);
            }
        }
        
        protected GameObject GetObjectFromPool(List<GameObject> objectPool, GameObject objectPrefab)
        {
            foreach (GameObject obj in objectPool)
            {
                if (!obj.activeInHierarchy)
                {
                    obj.SetActive(true);
                    return obj;
                }
            }
            GameObject newObj = Instantiate(objectPrefab);
            objectPool.Add(newObj);
            return newObj;
        }
    }
}