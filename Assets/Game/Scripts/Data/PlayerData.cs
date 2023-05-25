using UnityEngine;

namespace Game.Scripts.Data
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/CreatePlayerData")]
    public class PlayerData : ScriptableObject
    {
        public float MovementSpeed;
    }
}