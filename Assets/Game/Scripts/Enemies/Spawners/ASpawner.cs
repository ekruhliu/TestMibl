using System.Collections;
using Game.Scripts.Structs;
using UnityEngine;

namespace Game.Scripts.Enemies.Spawners
{
    public abstract class ASpawner : MonoBehaviour
    {
        protected abstract IEnumerator SpawnObjectsCoroutine();
        protected abstract void StopCoroutineOnGameOver();
        protected Vector3 GetRandomPositionOnSurface(Bounds spawnBounds)
        {
            float radius = spawnBounds.extents.x;

            Vector2 randomCirclePoint = Random.insideUnitCircle * radius;
            Vector3 spawnPosition = new Vector3(randomCirclePoint.x, 2f, randomCirclePoint.y);

            return spawnPosition;
        }
    }
}