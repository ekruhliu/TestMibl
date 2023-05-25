using System;
using System.Collections;
using Game.Scripts.Data;
using Game.Scripts.Structs;
using Game.Scripts.UI;
using UnityEngine;

namespace Game.Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {
        public event Action OnPlayerDieAction;
        
        [SerializeField] private PlayerData _playerData;
        [SerializeField] private ParticleSystem _explosionParticle;
        private Rigidbody _rigidbody;
        private VariableJoystick _joystick;
        private bool _canMove;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _joystick = UIManager.Instance.VariableJoystick;
            _canMove = true;
        }

        private void FixedUpdate()
        {
            if(!_canMove)
                return;
            _rigidbody.velocity = new Vector3(_joystick.Horizontal * _playerData.MovementSpeed, _rigidbody.velocity.y, _joystick.Vertical * _playerData.MovementSpeed);
            if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
                transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Tags.Enemy))
            {
                _canMove = false;
                _rigidbody.velocity = Vector3.zero;
                _explosionParticle.Play();
                OnPlayerDieAction?.Invoke();
            }
        }
    }
}