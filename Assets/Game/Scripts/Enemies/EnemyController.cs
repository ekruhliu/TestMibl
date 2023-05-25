using System;
using Game.Scripts.Core;
using Game.Scripts.Data;
using UnityEngine;
using UnityEngine.AI;

namespace Game.Scripts.Enemies
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private EnemyData _enemyData;
        private NavMeshAgent _agent;
        private Transform _targer;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
        }

        private void Start()
        {
            _agent.speed = _enemyData.EnemySpeed;
            _targer = GameManager.Instance.Player.transform;
        }

        private void OnEnable()
        {
            GameManager.Instance.OnGameOverAction += StopAgent;
        }

        private void OnDisable()
        {
            GameManager.Instance.OnGameOverAction -= StopAgent;
        }

        private void FixedUpdate()
        {
            Pursuiting();
        }

        private void Pursuiting()
        {
            if(_agent.enabled)
                _agent.SetDestination(_targer.transform.position);
        }

        private void StopAgent()
        {
            _agent.enabled = false;
        }
    }
}