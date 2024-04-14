using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI
{
    public class StartScreen : MonoBehaviour
    {
        [SerializeField] private Button startBtn;
        [SerializeField] private CanvasGroup canvas;
        private bool gameStarted;

        private void Awake()
        {
            startBtn.onClick.AddListener(StartGame);
        }

        void StartGame()
        {
            if (gameStarted)
                return;
            gameStarted = true;
            DOTween.To(() => canvas.alpha, x => canvas.alpha = x, 0, 1f).OnComplete(() =>
            {
                gameObject.SetActive(false);
            });
        }
    }
}