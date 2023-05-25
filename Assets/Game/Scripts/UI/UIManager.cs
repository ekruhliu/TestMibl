using System;
using DG.Tweening;
using Game.Scripts.Core;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game.Scripts.UI
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance { get; private set; }
        public VariableJoystick VariableJoystick { get; private set; }

        [SerializeField] private GameObject _gameOverUI;
        [SerializeField] private Image _background;
        [SerializeField] private TextMeshProUGUI _timeText;
        [SerializeField] private Transform _tryAgainButton;

        private void Awake()
        {
            if (!Instance)
                Instance = this;
            else
                Destroy(gameObject);    
            VariableJoystick = GetComponentInChildren<VariableJoystick>();
        }

        private void OnEnable()
        {
            GameManager.Instance.OnSetGameTimeAction += OpenGameOverUI;
        }

        private void OnDisable()
        {
            GameManager.Instance.OnSetGameTimeAction -= OpenGameOverUI;
        }

        private void OpenGameOverUI(string time)
        {
            Sequence gameOverMenuSequence = DOTween.Sequence();
            this.VariableJoystick.enabled = false;
            _gameOverUI.SetActive(true);
            _timeText.text = time;
            gameOverMenuSequence.Append(_background.DOFade(0.35f, 1f));
            gameOverMenuSequence.Append(_timeText.transform.DOScale(1f, 1f));
            gameOverMenuSequence.Join(_tryAgainButton.DOScale(1f, 1f));
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}