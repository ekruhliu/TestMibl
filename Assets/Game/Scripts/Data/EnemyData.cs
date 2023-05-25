using UnityEngine;

namespace Game.Scripts.Data
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "ScriptableObjects/CreateEnemyData")]
    public class EnemyData : ScriptableObject
    {
        public float EnemySpeed;
        public Vector2 EnemySpawnCooldownRange;
        public Vector2 MineSpawnCooldownRange;
    }
}